// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Manage_Deployments_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using System.Text.Json;
using System.IO;
using JsonObject = System.Collections.Generic.Dictionary<string, object>;
using System.Security.Policy;
#endregion Manage_Deployments_Namespaces

namespace Azure.ResourceManager.Resources.Tests.Samples
{
    public class Sample2_ManagingDeployments
    {
        private ResourceGroupResource resourceGroup;

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateDeployments()
        {
            #region Snippet:Managing_Deployments_CreateADeployment
            // First we need to get the deployment collection from the resource group
            DeploymentCollection deploymentCollection = resourceGroup.GetDeployments();
            // Use the same location as the resource group
            string deploymentName = "myDeployment";
            var input = new DeploymentInput(new DeploymentProperties(DeploymentMode.Incremental)
            {
                TemplateLink = new TemplateLink()
                {
                    Uri = new Uri("https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/quickstarts/microsoft.storage/storage-account-create/azuredeploy.json")
                },
                Parameters = new JsonObject()
                {
                    {"storageAccountType", new JsonObject()
                        {
                            {"value", "Standard_GRS" }
                        }
                    }
                }
            });
            ArmOperation<DeploymentResource> lro = await deploymentCollection.CreateOrUpdateAsync(WaitUntil.Completed, deploymentName, input);
            DeploymentResource deployment = lro.Value;
            #endregion Snippet:Managing_Deployments_CreateADeployment
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateDeploymentsUsingJsonElement()
        {
            #region Snippet:Managing_Deployments_CreateADeploymentUsingJsonElement
            // First we need to get the deployment collection from the resource group
            DeploymentCollection deploymentCollection = resourceGroup.GetDeployments();
            // Use the same location as the resource group
            string deploymentName = "myDeployment";
            // Create a parameter object
            var parametersObject = new { storageAccountType = new { value = "Standard_GRS" } };
            //convert this object to JsonElement
            var parametersString = JsonSerializer.Serialize(parametersObject);
            var parameters = JsonDocument.Parse(parametersString).RootElement;
            var input = new DeploymentInput(new DeploymentProperties(DeploymentMode.Incremental)
            {
                TemplateLink = new TemplateLink()
                {
                    Uri = new Uri("https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/quickstarts/microsoft.storage/storage-account-create/azuredeploy.json")
                },
                Parameters = parameters
            });
            ArmOperation<DeploymentResource> lro = await deploymentCollection.CreateOrUpdateAsync(WaitUntil.Completed, deploymentName, input);
            DeploymentResource deployment = lro.Value;
            #endregion Snippet:Managing_Deployments_CreateADeployment
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task CreateDeploymentsUsingString()
        {
            #region Snippet:Managing_Deployments_CreateADeploymentUsingString
            // First we need to get the deployment collection from the resource group
            DeploymentCollection deploymentCollection = resourceGroup.GetDeployments();
            // Use the same location as the resource group
            string deploymentName = "myDeployment";
            // Passing string to template and parameters
            var input = new DeploymentInput(new DeploymentProperties(DeploymentMode.Incremental)
            {
                Template = File.ReadAllText("storage-template.json"),
                Parameters = File.ReadAllText("storage-parameters.json")
            });
            ArmOperation<DeploymentResource> lro = await deploymentCollection.CreateOrUpdateAsync(WaitUntil.Completed, deploymentName, input);
            DeploymentResource deployment = lro.Value;
            #endregion Snippet:Managing_Deployments_CreateADeployment
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ListDeployments()
        {
            #region Snippet:Managing_Deployments_ListAllDeployments
            // First we need to get the deployment collection from the resource group
            DeploymentCollection deploymentCollection = resourceGroup.GetDeployments();
            // With GetAllAsync(), we can get a list of the deployments in the collection
            AsyncPageable<DeploymentResource> response = deploymentCollection.GetAllAsync();
            await foreach (DeploymentResource deployment in response)
            {
                Console.WriteLine(deployment.Data.Name);
            }
            #endregion Snippet:Managing_Deployments_ListAllDeployments
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task DeleteDeployments()
        {
            #region Snippet:Managing_Deployments_DeleteADeployment
            // First we need to get the deployment collection from the resource group
            DeploymentCollection deploymentCollection = resourceGroup.GetDeployments();
            // Now we can get the deployment with GetAsync()
            DeploymentResource deployment = await deploymentCollection.GetAsync("myDeployment");
            // With DeleteAsync(), we can delete the deployment
            await deployment.DeleteAsync(WaitUntil.Completed);
            #endregion Snippet:Managing_Deployments_DeleteADeployment
        }

        [SetUp]
        protected async Task initialize()
        {
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();

            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
            // With the collection, we can create a new resource group with an specific name
            string rgName = "myRgName";
            AzureLocation location = AzureLocation.WestUS2;
            ArmOperation<ResourceGroupResource> lro = await rgCollection.CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(location));
            ResourceGroupResource resourceGroup = lro.Value;

            this.resourceGroup = resourceGroup;
        }
    }
}
