"""Reading tuple elements and unpacking in Python."""

from __future__ import annotations


def run() -> None:
    print("=== Index access ===")
    result = (200, "OK")
    print(f"result[0] = {result[0]}")
    print(f"result[1] = {result[1]!r}")
    print(f"result[-1]= {result[-1]!r}  (last)")

    print("\n=== Unpacking ===")
    code, message = (404, "Not Found")
    print(f"code={code}, message={message!r}")

    # Swap.
    a, b = 1, 2
    a, b = b, a
    print(f"After swap: a={a}, b={b}")

    # Extended unpacking.
    first, *rest = (10, 20, 30, 40)
    print(f"first={first}, rest={rest}")

    *head, last = (10, 20, 30, 40)
    print(f"head={head}, last={last}")

    print("\n=== Ignoring elements with _ ===")
    user_id, _, role = ("u1", "Ann", "admin")
    print(f"id={user_id!r}, role={role!r}  (name discarded)")


if __name__ == "__main__":
    run()
