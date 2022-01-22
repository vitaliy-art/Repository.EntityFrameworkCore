public class Model
{
    public Guid Id { get; set; }
    public string? Name { get; set; }

    public override string ToString() =>
        $"{nameof(Model)}: {{ {nameof(Id)}: {Id}, {nameof(Name)}: {Name} }}";
}
