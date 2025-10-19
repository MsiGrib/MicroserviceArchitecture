from ImagesServices.ImageDescriber import AnalyzeImageFileDescription
from setup_env import check_and_install

if __name__ == "__main__":
    check_and_install()
    print("\nAll necessary libraries are installed.\n")

    image_path = "Imgs/1.png"

    result = AnalyzeImageFileDescription(str(image_path))

    print("Caption:", result["caption"])
    print("Labels:")
    for lbl, score in result["labels"]:
        print(f"  {lbl}: {score:.4f}")