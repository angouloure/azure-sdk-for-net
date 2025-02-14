// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Sql
{
    /// <summary>
    /// A class representing a collection of <see cref="ServerDatabaseSchemaResource" /> and their operations.
    /// Each <see cref="ServerDatabaseSchemaResource" /> in the collection will belong to the same instance of <see cref="SqlDatabaseResource" />.
    /// To get a <see cref="ServerDatabaseSchemaCollection" /> instance call the GetServerDatabaseSchemas method from an instance of <see cref="SqlDatabaseResource" />.
    /// </summary>
    public partial class ServerDatabaseSchemaCollection : ArmCollection, IEnumerable<ServerDatabaseSchemaResource>, IAsyncEnumerable<ServerDatabaseSchemaResource>
    {
        private readonly ClientDiagnostics _serverDatabaseSchemaDatabaseSchemasClientDiagnostics;
        private readonly DatabaseSchemasRestOperations _serverDatabaseSchemaDatabaseSchemasRestClient;

        /// <summary> Initializes a new instance of the <see cref="ServerDatabaseSchemaCollection"/> class for mocking. </summary>
        protected ServerDatabaseSchemaCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ServerDatabaseSchemaCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ServerDatabaseSchemaCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _serverDatabaseSchemaDatabaseSchemasClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ServerDatabaseSchemaResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ServerDatabaseSchemaResource.ResourceType, out string serverDatabaseSchemaDatabaseSchemasApiVersion);
            _serverDatabaseSchemaDatabaseSchemasRestClient = new DatabaseSchemasRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, serverDatabaseSchemaDatabaseSchemasApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SqlDatabaseResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SqlDatabaseResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Get database schema
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas/{schemaName}
        /// Operation Id: DatabaseSchemas_Get
        /// </summary>
        /// <param name="schemaName"> The name of the schema. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="schemaName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="schemaName"/> is null. </exception>
        public virtual async Task<Response<ServerDatabaseSchemaResource>> GetAsync(string schemaName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(schemaName, nameof(schemaName));

            using var scope = _serverDatabaseSchemaDatabaseSchemasClientDiagnostics.CreateScope("ServerDatabaseSchemaCollection.Get");
            scope.Start();
            try
            {
                var response = await _serverDatabaseSchemaDatabaseSchemasRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, schemaName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ServerDatabaseSchemaResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get database schema
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas/{schemaName}
        /// Operation Id: DatabaseSchemas_Get
        /// </summary>
        /// <param name="schemaName"> The name of the schema. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="schemaName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="schemaName"/> is null. </exception>
        public virtual Response<ServerDatabaseSchemaResource> Get(string schemaName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(schemaName, nameof(schemaName));

            using var scope = _serverDatabaseSchemaDatabaseSchemasClientDiagnostics.CreateScope("ServerDatabaseSchemaCollection.Get");
            scope.Start();
            try
            {
                var response = _serverDatabaseSchemaDatabaseSchemasRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, schemaName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ServerDatabaseSchemaResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List database schemas
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas
        /// Operation Id: DatabaseSchemas_ListByDatabase
        /// </summary>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ServerDatabaseSchemaResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ServerDatabaseSchemaResource> GetAllAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ServerDatabaseSchemaResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _serverDatabaseSchemaDatabaseSchemasClientDiagnostics.CreateScope("ServerDatabaseSchemaCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _serverDatabaseSchemaDatabaseSchemasRestClient.ListByDatabaseAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ServerDatabaseSchemaResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ServerDatabaseSchemaResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _serverDatabaseSchemaDatabaseSchemasClientDiagnostics.CreateScope("ServerDatabaseSchemaCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _serverDatabaseSchemaDatabaseSchemasRestClient.ListByDatabaseNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ServerDatabaseSchemaResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// List database schemas
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas
        /// Operation Id: DatabaseSchemas_ListByDatabase
        /// </summary>
        /// <param name="filter"> An OData filter expression that filters elements in the collection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ServerDatabaseSchemaResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ServerDatabaseSchemaResource> GetAll(string filter = null, CancellationToken cancellationToken = default)
        {
            Page<ServerDatabaseSchemaResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _serverDatabaseSchemaDatabaseSchemasClientDiagnostics.CreateScope("ServerDatabaseSchemaCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _serverDatabaseSchemaDatabaseSchemasRestClient.ListByDatabase(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ServerDatabaseSchemaResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ServerDatabaseSchemaResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _serverDatabaseSchemaDatabaseSchemasClientDiagnostics.CreateScope("ServerDatabaseSchemaCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _serverDatabaseSchemaDatabaseSchemasRestClient.ListByDatabaseNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ServerDatabaseSchemaResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas/{schemaName}
        /// Operation Id: DatabaseSchemas_Get
        /// </summary>
        /// <param name="schemaName"> The name of the schema. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="schemaName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="schemaName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string schemaName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(schemaName, nameof(schemaName));

            using var scope = _serverDatabaseSchemaDatabaseSchemasClientDiagnostics.CreateScope("ServerDatabaseSchemaCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(schemaName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas/{schemaName}
        /// Operation Id: DatabaseSchemas_Get
        /// </summary>
        /// <param name="schemaName"> The name of the schema. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="schemaName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="schemaName"/> is null. </exception>
        public virtual Response<bool> Exists(string schemaName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(schemaName, nameof(schemaName));

            using var scope = _serverDatabaseSchemaDatabaseSchemasClientDiagnostics.CreateScope("ServerDatabaseSchemaCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(schemaName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas/{schemaName}
        /// Operation Id: DatabaseSchemas_Get
        /// </summary>
        /// <param name="schemaName"> The name of the schema. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="schemaName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="schemaName"/> is null. </exception>
        public virtual async Task<Response<ServerDatabaseSchemaResource>> GetIfExistsAsync(string schemaName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(schemaName, nameof(schemaName));

            using var scope = _serverDatabaseSchemaDatabaseSchemasClientDiagnostics.CreateScope("ServerDatabaseSchemaCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _serverDatabaseSchemaDatabaseSchemasRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, schemaName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ServerDatabaseSchemaResource>(null, response.GetRawResponse());
                return Response.FromValue(new ServerDatabaseSchemaResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/schemas/{schemaName}
        /// Operation Id: DatabaseSchemas_Get
        /// </summary>
        /// <param name="schemaName"> The name of the schema. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="schemaName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="schemaName"/> is null. </exception>
        public virtual Response<ServerDatabaseSchemaResource> GetIfExists(string schemaName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(schemaName, nameof(schemaName));

            using var scope = _serverDatabaseSchemaDatabaseSchemasClientDiagnostics.CreateScope("ServerDatabaseSchemaCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _serverDatabaseSchemaDatabaseSchemasRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, schemaName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ServerDatabaseSchemaResource>(null, response.GetRawResponse());
                return Response.FromValue(new ServerDatabaseSchemaResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ServerDatabaseSchemaResource> IEnumerable<ServerDatabaseSchemaResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ServerDatabaseSchemaResource> IAsyncEnumerable<ServerDatabaseSchemaResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
