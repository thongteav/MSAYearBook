﻿namespace MSAYearBook.GraphQL.Projects
{
    public record AddProjectInput(
        string Name,
        string Description,
        string Link,
        string Year,
        string StudentId);
}