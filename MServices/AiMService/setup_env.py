import subprocess
import sys

REQUIRED_LIBS = [
    "torch",
    "torchvision",
    "torchaudio",
    "transformers",
    "Pillow",
    "hf_xet",
    "numpy",
    "requests",
]

def install_package(pkg_name):
    print(f"Install {pkg_name}...")
    subprocess.check_call([sys.executable, "-m", "pip", "install", "--upgrade", pkg_name])

def check_and_install():
    for lib in REQUIRED_LIBS:
        try:
            __import__(lib)
            print(f"{lib} already installed.")
        except ImportError:
            print(f"{lib} not found. Will be installed..")
            install_package(lib)