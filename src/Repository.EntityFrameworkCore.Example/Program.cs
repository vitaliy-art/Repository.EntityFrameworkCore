var factory = new SqliteRepositoryFactory();
var model = new Model() { Name = "ModelName" };
Console.WriteLine($"Created entity: {model}");
Guid id = default;

using (var repository = factory.GetRepository<Model>())
{
    await repository.AddAsync(model);
    Console.WriteLine($"Added entity: {model}");
    model.Name = "NewModelName";
    await repository.SaveAsync(model);
    id = model.Id;
}

Model? loadedModel = default;

using (var repository = factory.GetRepository<Model>())
{
    loadedModel = await repository.GetByIdAsync(id);
    Console.WriteLine($"Loaded entity: {loadedModel}");
}
