## 2025-05-14 - [Securing Default WinForms Data Binding]
**Vulnerability:** Default TableAdapter.UpdateAll calls in WinForms catch-less event handlers can leak stack traces to users via the default exception dialog and allow manual editing of primary keys.
**Learning:** Visual Studio's drag-and-drop data binding generates code that lacks input validation and secure error handling.
**Prevention:** Always wrap TableAdapter updates in try-catch blocks with generic error messages and set primary key UI controls to ReadOnly.
