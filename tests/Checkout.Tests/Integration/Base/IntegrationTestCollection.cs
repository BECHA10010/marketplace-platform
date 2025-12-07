namespace Checkout.Tests.Integration.Base;

[CollectionDefinition("IntegrationTests")]
public class IntegrationTestCollection : ICollectionFixture<PostgresContainerFixture> { }