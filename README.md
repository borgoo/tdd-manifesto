# TDD Manifesto

A personal collection of Test-Driven Development katas and learnings.

## Katas

The first 6 katas (Kata1-Kata6) are from [TDD Manifesto Exercises](https://tddmanifesto.com/exercises/).

Each kata follows the structure:
- `KataN.cs` - Implementation code
- `KataN.md` - Kata documentation and requirements

## What I've Learned

### Project Organization
1. **Maintain consistent project directory structure** - Mirror the production code structure in the test project for easy navigation and maintenance.

### Test Naming Convention
2. **Use descriptive test names following the pattern:** `LogicalComponentName_Scenario_ExpectedOutcome`
   - Example: `Withdraw_WhenAmountIsLessThan0_ThenThrowValidationException`

### Test Structure
3. **Follow the AAA pattern consistently:**
   - **Arrange** - Set up test data and dependencies
   - **Act** - Execute the method under test
   - **Assert** - Verify the expected outcome

### Test Setup
4. **Use SetUp method when possible** - Initialize common test dependencies in the `[SetUp]` method to reduce code duplication.

### Assertion Style
5. **Prefer constraint-based assertions:** Use `Assert.That(result, Is.EqualTo(expectedResult))` for better readability and error messages.

### Mocking Strategy
6. **Mock providers manually** - Create custom mock implementations of interfaces to maintain full control and understanding of test dependencies.

## Tips

### Running Specific Tests
```bash
dotnet test TDDManifesto.NUnit --filter "FullyQualifiedName~Kata4Test"
```
This command runs all tests in the `Kata4Test` class.

### General Approach
- Make reasonable assumptions when requirements are ambiguous
- Stick closely to kata instructions without overcomplicating the solution
- Exception: Kata6 explicitly requested additional complexity for learning purposes