# Kata 5: Point of Sale

Create a simple app for scanning bar codes to sell products.

## Requirements

### 1. Basic Product Scanning
- Barcode '12345' should display price '$7.25'
- Barcode '23456' should display price '$12.50'

### 2. Error Handling
- Barcode '99999' should display 'Error: barcode not found'
- Empty barcode should display 'Error: empty barcode'

### 3. Total Command
Introduce a concept of total command where it is possible to scan multiple items. The command would display the sum of the scanned product prices.