# test_acceptance_criteria
Test JSON Serialization inside AcceptanceCriteriaInstance classes

Results:

### Old

```json
{
 "TestResultCode":3,!"FiatInCompanyNumber":null!,
 "UserPersonalNumber":"001-456345","SomeEmptyField":"",
 "UserAddress":"Nils Grises Strate 40",
 "UserCity":"Kopparberg","UserPostalCode":"714 01",
 "UserFullName":"John Smith","UserPhoneNumber":"+46 8 678 55 00"
}
```

### New

```json
{
 "TestResultCode":3,
 "UserPersonalNumber":"001-456345","SomeEmptyField":"",
 "UserAddress":"Nils Grises Strate 40",
 "UserCity":"Kopparberg","UserPostalCode":"714 01",
 "UserFullName":"John Smith","UserPhoneNumber":"+46 8 678 55 00"
}
```
