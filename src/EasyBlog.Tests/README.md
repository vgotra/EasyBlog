# Playwright Tests

## Prerequisites

- use Playwright with NodeJs at Linux (check official documentation)

```shell
npm install playwright
npx playwright install
```

or

- install PowerShell Core (easier)

### Downloading web browsers for tests

```shell
pwsh bin/Debug/net8.0/playwright.ps1 install 
```

### For recording tests 

```shell
pwsh bin/Debug/net8.0/playwright.ps1 codegen https://localhost:7149/ --ignore-https-errors
```