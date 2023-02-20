namespace FootballTeamProject.Core.Entities
{
    public interface IEntityBase<TId>
    {
        TId Id { get; }

        bool Equals(object obj);
        int GetHashCode();
        bool IsTransient();
    }
}