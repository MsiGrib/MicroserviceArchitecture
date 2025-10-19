from pathlib import Path
from typing import Dict, Any

def AnalyzeImageFileDescription(image_path: str) -> Dict[str, Any]:
    image_path = Path(image_path)
    if not image_path.exists():
        raise FileNotFoundError(f"File not found: {image_path}")

    caption = None
    labels = []

    try:
        from PIL import Image
    except ImportError:
        raise ImportError("Pillow required. Install: pip install Pillow")

    img = Image.open(image_path).convert("RGB")

    try:
        import torch
        device_id = 0 if torch.cuda.is_available() else -1  # transformers
        torch_device = torch.device("cuda" if torch.cuda.is_available() else "cpu")
    except ImportError:
        device_id = -1
        torch_device = None

    try:
        from transformers import pipeline
        it_pipeline = pipeline(
            "image-to-text",
            model="Salesforce/blip-image-captioning-base",
            device=device_id
        )
        out = it_pipeline(img)
        if isinstance(out, list) and len(out) > 0:
            first = out[0]
            caption = first.get("generated_text") or first.get("caption") or str(first)
    except Exception:
        caption = None

    try:
        from transformers import pipeline
        clf = pipeline(
            "image-classification",
            model="google/vit-base-patch16-224",
            top_k=5,
            device=device_id
        )
        res = clf(img)
        if isinstance(res, list) and len(res) > 0:
            if isinstance(res[0], dict):
                labels = [(r.get("label"), float(r.get("score", 0))) for r in res]
            elif isinstance(res[0], list):
                labels = [(r.get("label"), float(r.get("score", 0))) for r in res[0]]
    except Exception:
        try:
            import torch
            import torchvision.transforms as T
            from torchvision import models

            transform = T.Compose([
                T.Resize(256),
                T.CenterCrop(224),
                T.ToTensor(),
                T.Normalize(mean=[0.485, 0.456, 0.406],
                            std=[0.229, 0.224, 0.225]),
            ])
            input_tensor = transform(img).unsqueeze(0).to(torch_device)

            model = models.resnet50(pretrained=True).to(torch_device)
            model.eval()

            with torch.no_grad():
                out = model(input_tensor)
                probs = torch.nn.functional.softmax(out[0], dim=0)
                top5 = torch.topk(probs, k=5)
                labels = [(str(i), float(s)) for i, s in zip(top5.indices.tolist(), top5.values.tolist())]
        except Exception:
            labels = []

    return {"caption": caption, "labels": labels}