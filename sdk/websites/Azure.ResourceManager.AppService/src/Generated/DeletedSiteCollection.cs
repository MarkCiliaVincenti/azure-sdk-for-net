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
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.AppService
{
    /// <summary> A class representing collection of DeletedSite and their operations over its parent. </summary>
    public partial class DeletedSiteCollection : ArmCollection, IEnumerable<DeletedSite>, IAsyncEnumerable<DeletedSite>
    {
        private readonly ClientDiagnostics _deletedSiteGlobalClientDiagnostics;
        private readonly GlobalRestOperations _deletedSiteGlobalRestClient;
        private readonly ClientDiagnostics _deletedSiteDeletedWebAppsClientDiagnostics;
        private readonly DeletedWebAppsRestOperations _deletedSiteDeletedWebAppsRestClient;

        /// <summary> Initializes a new instance of the <see cref="DeletedSiteCollection"/> class for mocking. </summary>
        protected DeletedSiteCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="DeletedSiteCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal DeletedSiteCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _deletedSiteGlobalClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppService", DeletedSite.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(DeletedSite.ResourceType, out string deletedSiteGlobalApiVersion);
            _deletedSiteGlobalRestClient = new GlobalRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, deletedSiteGlobalApiVersion);
            _deletedSiteDeletedWebAppsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppService", DeletedSite.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(DeletedSite.ResourceType, out string deletedSiteDeletedWebAppsApiVersion);
            _deletedSiteDeletedWebAppsRestClient = new DeletedWebAppsRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, deletedSiteDeletedWebAppsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != Subscription.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, Subscription.ResourceType), nameof(id));
        }

        /// <summary>
        /// Description for Get deleted app for a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Web/deletedSites/{deletedSiteId}
        /// Operation Id: Global_GetDeletedWebApp
        /// </summary>
        /// <param name="deletedSiteId"> The numeric ID of the deleted app, e.g. 12345. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deletedSiteId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deletedSiteId"/> is null. </exception>
        public virtual async Task<Response<DeletedSite>> GetAsync(string deletedSiteId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deletedSiteId, nameof(deletedSiteId));

            using var scope = _deletedSiteGlobalClientDiagnostics.CreateScope("DeletedSiteCollection.Get");
            scope.Start();
            try
            {
                var response = await _deletedSiteGlobalRestClient.GetDeletedWebAppAsync(Id.SubscriptionId, deletedSiteId, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DeletedSite(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Get deleted app for a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Web/deletedSites/{deletedSiteId}
        /// Operation Id: Global_GetDeletedWebApp
        /// </summary>
        /// <param name="deletedSiteId"> The numeric ID of the deleted app, e.g. 12345. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deletedSiteId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deletedSiteId"/> is null. </exception>
        public virtual Response<DeletedSite> Get(string deletedSiteId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deletedSiteId, nameof(deletedSiteId));

            using var scope = _deletedSiteGlobalClientDiagnostics.CreateScope("DeletedSiteCollection.Get");
            scope.Start();
            try
            {
                var response = _deletedSiteGlobalRestClient.GetDeletedWebApp(Id.SubscriptionId, deletedSiteId, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DeletedSite(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Get all deleted apps for a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Web/deletedSites
        /// Operation Id: DeletedWebApps_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DeletedSite" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DeletedSite> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<DeletedSite>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _deletedSiteDeletedWebAppsClientDiagnostics.CreateScope("DeletedSiteCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _deletedSiteDeletedWebAppsRestClient.ListAsync(Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DeletedSite(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DeletedSite>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _deletedSiteDeletedWebAppsClientDiagnostics.CreateScope("DeletedSiteCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _deletedSiteDeletedWebAppsRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DeletedSite(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Description for Get all deleted apps for a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Web/deletedSites
        /// Operation Id: DeletedWebApps_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DeletedSite" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DeletedSite> GetAll(CancellationToken cancellationToken = default)
        {
            Page<DeletedSite> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _deletedSiteDeletedWebAppsClientDiagnostics.CreateScope("DeletedSiteCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _deletedSiteDeletedWebAppsRestClient.List(Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DeletedSite(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DeletedSite> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _deletedSiteDeletedWebAppsClientDiagnostics.CreateScope("DeletedSiteCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _deletedSiteDeletedWebAppsRestClient.ListNextPage(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DeletedSite(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Web/deletedSites/{deletedSiteId}
        /// Operation Id: Global_GetDeletedWebApp
        /// </summary>
        /// <param name="deletedSiteId"> The numeric ID of the deleted app, e.g. 12345. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deletedSiteId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deletedSiteId"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string deletedSiteId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deletedSiteId, nameof(deletedSiteId));

            using var scope = _deletedSiteGlobalClientDiagnostics.CreateScope("DeletedSiteCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(deletedSiteId, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Web/deletedSites/{deletedSiteId}
        /// Operation Id: Global_GetDeletedWebApp
        /// </summary>
        /// <param name="deletedSiteId"> The numeric ID of the deleted app, e.g. 12345. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deletedSiteId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deletedSiteId"/> is null. </exception>
        public virtual Response<bool> Exists(string deletedSiteId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deletedSiteId, nameof(deletedSiteId));

            using var scope = _deletedSiteGlobalClientDiagnostics.CreateScope("DeletedSiteCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(deletedSiteId, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Web/deletedSites/{deletedSiteId}
        /// Operation Id: Global_GetDeletedWebApp
        /// </summary>
        /// <param name="deletedSiteId"> The numeric ID of the deleted app, e.g. 12345. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deletedSiteId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deletedSiteId"/> is null. </exception>
        public virtual async Task<Response<DeletedSite>> GetIfExistsAsync(string deletedSiteId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deletedSiteId, nameof(deletedSiteId));

            using var scope = _deletedSiteGlobalClientDiagnostics.CreateScope("DeletedSiteCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _deletedSiteGlobalRestClient.GetDeletedWebAppAsync(Id.SubscriptionId, deletedSiteId, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<DeletedSite>(null, response.GetRawResponse());
                return Response.FromValue(new DeletedSite(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Web/deletedSites/{deletedSiteId}
        /// Operation Id: Global_GetDeletedWebApp
        /// </summary>
        /// <param name="deletedSiteId"> The numeric ID of the deleted app, e.g. 12345. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="deletedSiteId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="deletedSiteId"/> is null. </exception>
        public virtual Response<DeletedSite> GetIfExists(string deletedSiteId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(deletedSiteId, nameof(deletedSiteId));

            using var scope = _deletedSiteGlobalClientDiagnostics.CreateScope("DeletedSiteCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _deletedSiteGlobalRestClient.GetDeletedWebApp(Id.SubscriptionId, deletedSiteId, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<DeletedSite>(null, response.GetRawResponse());
                return Response.FromValue(new DeletedSite(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<DeletedSite> IEnumerable<DeletedSite>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<DeletedSite> IAsyncEnumerable<DeletedSite>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
