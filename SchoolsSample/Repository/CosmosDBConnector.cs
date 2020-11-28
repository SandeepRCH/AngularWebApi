using Microsoft.Azure.Cosmos;

using Models;

using System;
using System.Threading.Tasks;

namespace Repository
{
    public class CosmosDBConnector
    {
        private const string EndpointUrl = "https://localhost:8081";
        private const string AuthorizationKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        private const string DatabaseId = "EducationDepartment";
        private const string SchoolsContainerId = "SchoolContainer";
        private const string StudentContainerId = "StudentContainer";
        private const string PartitionKey = "/SchoolCode";
        public CosmosClient cosmosClient { get; set; }

        public CosmosDBConnector()
        {
            this.cosmosClient = new CosmosClient(EndpointUrl, AuthorizationKey);
        }

        public Container GetContainer<T>()
        {
            if (typeof(T) == typeof(Student))
            {
                return this.GetStudentContainer();
            }
            else if (typeof(T) == typeof(School))
            {
                return this.GetSchoolContainer();
            }
            else
            {
                throw new Exception("Container not found");
            }
        }

        public async Task AddDocument<T>(T student)
        {
            var container = this.GetStudentContainer();
            var options = new ItemRequestOptions()
            {
                 ConsistencyLevel = ConsistencyLevel.Strong,
            };
            await container.CreateItemAsync<T>(student, new PartitionKey(PartitionKey), options);
        }

        public async Task GetDocument<T>(string code)
        {
            var container = this.GetContainer<T>();
        }

        private  Container GetSchoolContainer()
        {
            return this.cosmosClient.GetContainer(DatabaseId, SchoolsContainerId);
        }

        public Container GetStudentContainer()
        {
            return this.cosmosClient.GetContainer(DatabaseId, StudentContainerId);
        }
    }
}
