"""Practical QA automation examples using Python sets."""
from __future__ import annotations

def run() -> None:
    print("=== Deduplicate test environment URLs ===")
    env_urls = [
        "https://staging.example.com",
        "https://prod.example.com",
        "https://staging.example.com",
        "HTTPS://STAGING.EXAMPLE.COM",
    ]
    unique = {url.lower() for url in env_urls}
    print(f"Input:  {len(env_urls)} URLs")
    print(f"Unique: {len(unique)} URLs")
    for url in sorted(unique):
        print(f"  {url}")

    print("\n=== Verify API response has all required fields ===")
    required = {"id", "name", "email", "role", "createdAt"}
    returned = {"id", "name", "email", "createdAt"}
    missing = required - returned
    extra = returned - required
    print(f"Missing: {missing}")
    print(f"Extra:   {extra}")
    print("PASS" if not missing else "FAIL: missing fields")

    print("\n=== Find untested endpoints ===")
    all_endpoints = {"GET /users", "POST /users", "GET /users/{id}", "PUT /users/{id}", "DELETE /users/{id}", "GET /orders"}
    tested = {"GET /users", "POST /users", "GET /users/{id}"}
    untested = sorted(all_endpoints - tested)
    print(f"Total: {len(all_endpoints)}  Tested: {len(tested)}  Untested: {len(untested)}")
    for ep in untested:
        print(f"  ○ {ep}")

if __name__ == "__main__":
    run()
