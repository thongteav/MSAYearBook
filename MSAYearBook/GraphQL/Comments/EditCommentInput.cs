namespace MSAYearBook.GraphQL.Comments
{
    public record EditCommentInput(
        string CommentId,
        string? Content);
}