# Kata 3 – Password Input Field Validation

Create a function that can be used as a validator for the password field of a user registration form. The validation function takes a string as an input and returns a validation result. The validation result should contain a boolean indicating if the password is valid or not, and also a field with the possible validation errors.

## Requirements

### 1. Minimum Length
The password must be at least 8 characters long. If it is not met, then the following error message should be returned: 
`"Password must be at least 8 characters"`

### 2. Number Requirement
The password must contain at least 2 numbers. If it is not met, then the following error message should be returned: 
`"The password must contain at least 2 numbers"`

### 3. Multiple Validation Errors
The validation function should handle multiple validation errors.

**Example:** 
`"somepassword"` should return an error message: 
`"Password must be at least 8 characters\nThe password must contain at least 2 numbers"`

### 4. Capital Letter Requirement
The password must contain at least one capital letter. If it is not met, then the following error message should be returned: 
`"password must contain at least one capital letter"`

### 5. Special Character Requirement
The password must contain at least one special character. If it is not met, then the following error message should be returned: 
`"password must contain at least one special character"`