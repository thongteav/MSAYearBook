﻿namespace MSAYearBook.GraphQL.Comments
{
    public record AddCommentInput(
        string Content,
        string ProjectId,
        string StudentId);
}