"""Practical QA automation examples using Python tuples."""

from __future__ import annotations

from typing import NamedTuple


class ElementInfo(NamedTuple):
    selector: str
    is_visible: bool


class ValidationResult(NamedTuple):
    is_valid: bool
    error: str


def get_login_button() -> ElementInfo:
    return ElementInfo(selector="#login-btn", is_visible=True)


def validate_email(email: str) -> ValidationResult:
    is_valid = "@" in email and "." in email
    return ValidationResult(is_valid=is_valid, error="" if is_valid else "Invalid email format")


def get_test_config(env: str) -> list[tuple[str, str]]:
    return [
        ("BASE_URL", f"https://{env}.example.com"),
        ("TIMEOUT_SEC", "30"),
        ("HEADLESS", "true"),
    ]


def run() -> None:
    print("=== Page object method returning element info ===")
    btn = get_login_button()
    print(f"Selector: {btn.selector!r}, Visible: {btn.is_visible}")
    if btn.is_visible:
        print("Proceeding to click login button")

    print("\n=== Validation returning (is_valid, error) ===")
    for email in ["alice@test.com", "not-an-email", "bob@example.org"]:
        result = validate_email(email)
        msg = "" if result.is_valid else f"  error: {result.error}"
        print(f"  {email:<25} valid={result.is_valid}{msg}")

    print("\n=== Environment config as list of (key, value) tuples ===")
    config = get_test_config("staging")
    for key, value in config:
        print(f"  {key:<15} = {value}")


if __name__ == "__main__":
    run()
