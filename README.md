# Employee time control
In this repository creating database for motitoring employees work attendance by electronic card is presented.

|   Project status|  |
| ------------- |:-------------|
| Build status  | [![Build status](https://ci.appveyor.com/api/projects/status/9nqm94mec0j1dr2p?svg=true)](https://ci.appveyor.com/project/AlexSopov/employee-time-control) |
| Project Certification     |[![Codacy Badge](https://api.codacy.com/project/badge/Grade/ae3322a00bf1435da90e91e4ed0d06ac)](https://www.codacy.com/app/AlexSopov/employee-time-control?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=AlexSopov/employee-time-control&amp;utm_campaign=Badge_Grade)      |
| Code coverage | [![codecov](https://codecov.io/gh/AlexSopov/employee-time-control/branch/master/graph/badge.svg)](https://codecov.io/gh/AlexSopov/employee-time-control)      |

See more details here: [Raw Report](https://github.com/AlexSopov/employee-time-control/blob/master/Content/Report.docx?raw=true)

### Database schema
![Image](https://github.com/AlexSopov/employee-time-control/blob/master/Content/Diagram.jpg?raw=true)

### Most useful sql queries 

History of employee attendance:
```sql
SELECT * 
FROM AccessAttemptions AS aas 
WHERE aas.CardId IN 
	(SELECT Cards.CardId 
	 FROM Cards
	 WHERE Cards.EmployeeId = @id);
```

Generate list of employees, who comes later than expected:
```sql
SELECT empl.EmployeeId, empl.FirstName, empl.SecondName, empl.JobTitle, empl.VisitingRuleId 
FROM Employees AS empl
	JOIN Cards ON Cards.EmployeeId = empl.EmployeeId
	JOIN AccessAttemptions AS aas ON aas.CardId = Cards.CardId
WHERE cast(aas.AttemptionTime as time) >
(
	SELECT cast(dvr.StartWorkingDay as time)
	FROM DayVisitingRules as dvr
		JOIN VisitingRules AS vis ON dvr.VisitingRuleId = vis.VisitingRuleId
		JOIN Employees AS empl ON empl.VisitingRuleId = vis.VisitingRuleId
		JOIN Cards AS ca ON ca.CardId = empl.EmployeeId
	WHERE ca.CardId = aas.CardId AND dvr.DayOfWeek + 1 = DATEPART(weekday, aas.AttemptionTime)
)  
AND aas.IsEnter = 1
AND NOT aas.AttemptionTime IN
(
	SELECT do.DayOffDate 
	FROM DayOffs AS do
		JOIN Employees ON Employees.EmployeeId = do.EmployeeId
		JOIN Cards ON Cards.CardId = aas.CardId
)
AND aas.AttemptionTime BETWEEN @from AND @to
```

Generate list of employee, who work less than expected:
```sql
SELECT empl.EmployeeId, empl.FirstName, empl.SecondName, empl.JobTitle, empl.VisitingRuleId 
    FROM Employees AS empl
            JOIN Cards ON Cards.EmployeeId = empl.EmployeeId
            JOIN AccessAttemptions AS aas ON aas.CardId = Cards.CardId
    WHERE cast(aas.AttemptionTime as time) >
    (
        SELECT cast(dvr.StartWorkingDay as time)
            FROM DayVisitingRules as dvr
                JOIN VisitingRules AS vis ON dvr.VisitingRuleId = vis.VisitingRuleId
                JOIN Employees AS empl ON empl.VisitingRuleId = vis.VisitingRuleId
                JOIN Cards AS ca ON ca.CardId = empl.EmployeeId
            WHERE ca.CardId = aas.CardId AND dvr.DayOfWeek + 1 = DATEPART(weekday, aas.AttemptionTime)
    )  AND aas.IsEnter = 1
    AND NOT aas.AttemptionTime IN
    (
        SELECT do.DayOffDate FROM DayOffs AS do
                JOIN Employees ON Employees.EmployeeId = do.EmployeeId
                JOIN Cards ON Cards.CardId = aas.CardId
  )
  AND aas.AttemptionTime BETWEEN @from AND @to
```
