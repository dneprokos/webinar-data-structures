"""Reading from Python dicts: safe access and iteration."""
from __future__ import annotations

def run() -> None:
    print("=== Read by key ===")
    config = {"base_url": "https://api.example.com", "timeout": "30"}
    print(f'config["base_url"]     = {config["base_url"]!r}')

    print("\n=== Safe access ===")
    print(f"get(missing,default)   = {config.get('missing', 'default')!r}")
    print(f"'timeout' in config    = {'timeout' in config}")
    val = config.get("timeout")
    print(f"get('timeout')         = {val!r}")

    print("\n=== Iterating ===")
    for key, value in sorted(config.items()):
        print(f"  {key:<10} = {value!r}")

    print("\n=== Keys, values, items ===")
    print(f"keys:   {sorted(config.keys())}")
    print(f"values: {sorted(config.values())}")

if __name__ == "__main__":
    run()
