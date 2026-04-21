"""Practical QA automation examples using Python queues (deque)."""
from __future__ import annotations
from collections import deque

def run() -> None:
    print("=== Test execution queue ===")
    test_queue: deque[str] = deque([
        "login_happy_path", "login_wrong_password",
        "checkout_empty_cart", "search_no_results",
    ])
    print(f"Scheduled {len(test_queue)} tests:")
    results = []
    run_num = 1
    while test_queue:
        name = test_queue.popleft()
        status = "fail" if run_num % 2 == 0 else "pass"
        results.append((name, status))
        print(f"  [{run_num}] {name:<30} -> {status}")
        run_num += 1
    passed = sum(1 for _, s in results if s == "pass")
    print(f"Result: {passed}/{len(results)} passed")

    print("\n=== Rate limiter: max 2 per batch ===")
    requests: deque[str] = deque([
        "GET /api/users", "POST /api/orders", "GET /api/products",
        "DELETE /api/sessions", "GET /api/reports",
    ])
    batch = 1
    while requests:
        print(f"  Batch {batch}:")
        for _ in range(2):
            if requests:
                print(f"    processed: {requests.popleft()}")
        batch += 1

    print("\n=== Event processing ===")
    events: deque[str] = deque([
        "page_load", "user_click_login",
        "api_request_sent", "api_response_received", "page_redirect",
    ])
    while events:
        print(f"  [event] {events.popleft()}")

if __name__ == "__main__":
    run()
