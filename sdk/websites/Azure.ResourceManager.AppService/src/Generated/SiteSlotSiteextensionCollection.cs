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

namespace Azure.ResourceManager.AppService
{
    /// <summary>
    /// A class representing a collection of <see cref="SiteSlotSiteextensionResource" /> and their operations.
    /// Each <see cref="SiteSlotSiteextensionResource" /> in the collection will belong to the same instance of <see cref="SiteSlotResource" />.
    /// To get a <see cref="SiteSlotSiteextensionCollection" /> instance call the GetSiteSlotSiteextensions method from an instance of <see cref="SiteSlotResource" />.
    /// </summary>
    public partial class SiteSlotSiteextensionCollection : ArmCollection, IEnumerable<SiteSlotSiteextensionResource>, IAsyncEnumerable<SiteSlotSiteextensionResource>
    {
        private readonly ClientDiagnostics _siteSlotSiteextensionWebAppsClientDiagnostics;
        private readonly WebAppsRestOperations _siteSlotSiteextensionWebAppsRestClient;

        /// <summary> Initializes a new instance of the <see cref="SiteSlotSiteextensionCollection"/> class for mocking. </summary>
        protected SiteSlotSiteextensionCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SiteSlotSiteextensionCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SiteSlotSiteextensionCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _siteSlotSiteextensionWebAppsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppService", SiteSlotSiteextensionResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SiteSlotSiteextensionResource.ResourceType, out string siteSlotSiteextensionWebAppsApiVersion);
            _siteSlotSiteextensionWebAppsRestClient = new WebAppsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, siteSlotSiteextensionWebAppsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SiteSlotResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SiteSlotResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Description for Install site extension on a web site, or a deployment slot.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/siteextensions/{siteExtensionId}
        /// Operation Id: WebApps_InstallSiteExtensionSlot
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="siteExtensionId"> Site extension name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="siteExtensionId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="siteExtensionId"/> is null. </exception>
        public virtual async Task<ArmOperation<SiteSlotSiteextensionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string siteExtensionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(siteExtensionId, nameof(siteExtensionId));

            using var scope = _siteSlotSiteextensionWebAppsClientDiagnostics.CreateScope("SiteSlotSiteextensionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _siteSlotSiteextensionWebAppsRestClient.InstallSiteExtensionSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, siteExtensionId, cancellationToken).ConfigureAwait(false);
                var operation = new AppServiceArmOperation<SiteSlotSiteextensionResource>(new SiteSlotSiteextensionOperationSource(Client), _siteSlotSiteextensionWebAppsClientDiagnostics, Pipeline, _siteSlotSiteextensionWebAppsRestClient.CreateInstallSiteExtensionSlotRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, siteExtensionId).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Install site extension on a web site, or a deployment slot.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/siteextensions/{siteExtensionId}
        /// Operation Id: WebApps_InstallSiteExtensionSlot
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="siteExtensionId"> Site extension name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="siteExtensionId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="siteExtensionId"/> is null. </exception>
        public virtual ArmOperation<SiteSlotSiteextensionResource> CreateOrUpdate(WaitUntil waitUntil, string siteExtensionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(siteExtensionId, nameof(siteExtensionId));

            using var scope = _siteSlotSiteextensionWebAppsClientDiagnostics.CreateScope("SiteSlotSiteextensionCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _siteSlotSiteextensionWebAppsRestClient.InstallSiteExtensionSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, siteExtensionId, cancellationToken);
                var operation = new AppServiceArmOperation<SiteSlotSiteextensionResource>(new SiteSlotSiteextensionOperationSource(Client), _siteSlotSiteextensionWebAppsClientDiagnostics, Pipeline, _siteSlotSiteextensionWebAppsRestClient.CreateInstallSiteExtensionSlotRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, siteExtensionId).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Get site extension information by its ID for a web site, or a deployment slot.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/siteextensions/{siteExtensionId}
        /// Operation Id: WebApps_GetSiteExtensionSlot
        /// </summary>
        /// <param name="siteExtensionId"> Site extension name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="siteExtensionId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="siteExtensionId"/> is null. </exception>
        public virtual async Task<Response<SiteSlotSiteextensionResource>> GetAsync(string siteExtensionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(siteExtensionId, nameof(siteExtensionId));

            using var scope = _siteSlotSiteextensionWebAppsClientDiagnostics.CreateScope("SiteSlotSiteextensionCollection.Get");
            scope.Start();
            try
            {
                var response = await _siteSlotSiteextensionWebAppsRestClient.GetSiteExtensionSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, siteExtensionId, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SiteSlotSiteextensionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Get site extension information by its ID for a web site, or a deployment slot.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/siteextensions/{siteExtensionId}
        /// Operation Id: WebApps_GetSiteExtensionSlot
        /// </summary>
        /// <param name="siteExtensionId"> Site extension name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="siteExtensionId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="siteExtensionId"/> is null. </exception>
        public virtual Response<SiteSlotSiteextensionResource> Get(string siteExtensionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(siteExtensionId, nameof(siteExtensionId));

            using var scope = _siteSlotSiteextensionWebAppsClientDiagnostics.CreateScope("SiteSlotSiteextensionCollection.Get");
            scope.Start();
            try
            {
                var response = _siteSlotSiteextensionWebAppsRestClient.GetSiteExtensionSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, siteExtensionId, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SiteSlotSiteextensionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Get list of siteextensions for a web site, or a deployment slot.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/siteextensions
        /// Operation Id: WebApps_ListSiteExtensionsSlot
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SiteSlotSiteextensionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SiteSlotSiteextensionResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SiteSlotSiteextensionResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _siteSlotSiteextensionWebAppsClientDiagnostics.CreateScope("SiteSlotSiteextensionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _siteSlotSiteextensionWebAppsRestClient.ListSiteExtensionsSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteSlotSiteextensionResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SiteSlotSiteextensionResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _siteSlotSiteextensionWebAppsClientDiagnostics.CreateScope("SiteSlotSiteextensionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _siteSlotSiteextensionWebAppsRestClient.ListSiteExtensionsSlotNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteSlotSiteextensionResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Description for Get list of siteextensions for a web site, or a deployment slot.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/siteextensions
        /// Operation Id: WebApps_ListSiteExtensionsSlot
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SiteSlotSiteextensionResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SiteSlotSiteextensionResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SiteSlotSiteextensionResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _siteSlotSiteextensionWebAppsClientDiagnostics.CreateScope("SiteSlotSiteextensionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _siteSlotSiteextensionWebAppsRestClient.ListSiteExtensionsSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteSlotSiteextensionResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SiteSlotSiteextensionResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _siteSlotSiteextensionWebAppsClientDiagnostics.CreateScope("SiteSlotSiteextensionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _siteSlotSiteextensionWebAppsRestClient.ListSiteExtensionsSlotNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SiteSlotSiteextensionResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/siteextensions/{siteExtensionId}
        /// Operation Id: WebApps_GetSiteExtensionSlot
        /// </summary>
        /// <param name="siteExtensionId"> Site extension name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="siteExtensionId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="siteExtensionId"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string siteExtensionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(siteExtensionId, nameof(siteExtensionId));

            using var scope = _siteSlotSiteextensionWebAppsClientDiagnostics.CreateScope("SiteSlotSiteextensionCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(siteExtensionId, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/siteextensions/{siteExtensionId}
        /// Operation Id: WebApps_GetSiteExtensionSlot
        /// </summary>
        /// <param name="siteExtensionId"> Site extension name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="siteExtensionId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="siteExtensionId"/> is null. </exception>
        public virtual Response<bool> Exists(string siteExtensionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(siteExtensionId, nameof(siteExtensionId));

            using var scope = _siteSlotSiteextensionWebAppsClientDiagnostics.CreateScope("SiteSlotSiteextensionCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(siteExtensionId, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/siteextensions/{siteExtensionId}
        /// Operation Id: WebApps_GetSiteExtensionSlot
        /// </summary>
        /// <param name="siteExtensionId"> Site extension name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="siteExtensionId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="siteExtensionId"/> is null. </exception>
        public virtual async Task<Response<SiteSlotSiteextensionResource>> GetIfExistsAsync(string siteExtensionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(siteExtensionId, nameof(siteExtensionId));

            using var scope = _siteSlotSiteextensionWebAppsClientDiagnostics.CreateScope("SiteSlotSiteextensionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _siteSlotSiteextensionWebAppsRestClient.GetSiteExtensionSlotAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, siteExtensionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<SiteSlotSiteextensionResource>(null, response.GetRawResponse());
                return Response.FromValue(new SiteSlotSiteextensionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/slots/{slot}/siteextensions/{siteExtensionId}
        /// Operation Id: WebApps_GetSiteExtensionSlot
        /// </summary>
        /// <param name="siteExtensionId"> Site extension name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="siteExtensionId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="siteExtensionId"/> is null. </exception>
        public virtual Response<SiteSlotSiteextensionResource> GetIfExists(string siteExtensionId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(siteExtensionId, nameof(siteExtensionId));

            using var scope = _siteSlotSiteextensionWebAppsClientDiagnostics.CreateScope("SiteSlotSiteextensionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _siteSlotSiteextensionWebAppsRestClient.GetSiteExtensionSlot(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, siteExtensionId, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<SiteSlotSiteextensionResource>(null, response.GetRawResponse());
                return Response.FromValue(new SiteSlotSiteextensionResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SiteSlotSiteextensionResource> IEnumerable<SiteSlotSiteextensionResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SiteSlotSiteextensionResource> IAsyncEnumerable<SiteSlotSiteextensionResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
