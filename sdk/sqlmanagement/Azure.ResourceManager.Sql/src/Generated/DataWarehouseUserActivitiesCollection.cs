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
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    /// <summary> A class representing collection of DataWarehouseUserActivities and their operations over its parent. </summary>
    public partial class DataWarehouseUserActivitiesCollection : ArmCollection, IEnumerable<DataWarehouseUserActivities>, IAsyncEnumerable<DataWarehouseUserActivities>
    {
        private readonly ClientDiagnostics _dataWarehouseUserActivitiesDataWarehouseUserActivitiesClientDiagnostics;
        private readonly DataWarehouseUserActivitiesRestOperations _dataWarehouseUserActivitiesDataWarehouseUserActivitiesRestClient;

        /// <summary> Initializes a new instance of the <see cref="DataWarehouseUserActivitiesCollection"/> class for mocking. </summary>
        protected DataWarehouseUserActivitiesCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="DataWarehouseUserActivitiesCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal DataWarehouseUserActivitiesCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _dataWarehouseUserActivitiesDataWarehouseUserActivitiesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", DataWarehouseUserActivities.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(DataWarehouseUserActivities.ResourceType, out string dataWarehouseUserActivitiesDataWarehouseUserActivitiesApiVersion);
            _dataWarehouseUserActivitiesDataWarehouseUserActivitiesRestClient = new DataWarehouseUserActivitiesRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, dataWarehouseUserActivitiesDataWarehouseUserActivitiesApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SqlDatabase.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SqlDatabase.ResourceType), nameof(id));
        }

        /// <summary>
        /// Gets the user activities of a data warehouse which includes running and suspended queries
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/dataWarehouseUserActivities/{dataWarehouseUserActivityName}
        /// Operation Id: DataWarehouseUserActivities_Get
        /// </summary>
        /// <param name="dataWarehouseUserActivityName"> The activity name of the data warehouse. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DataWarehouseUserActivities>> GetAsync(DataWarehouseUserActivityName dataWarehouseUserActivityName, CancellationToken cancellationToken = default)
        {
            using var scope = _dataWarehouseUserActivitiesDataWarehouseUserActivitiesClientDiagnostics.CreateScope("DataWarehouseUserActivitiesCollection.Get");
            scope.Start();
            try
            {
                var response = await _dataWarehouseUserActivitiesDataWarehouseUserActivitiesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, dataWarehouseUserActivityName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DataWarehouseUserActivities(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the user activities of a data warehouse which includes running and suspended queries
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/dataWarehouseUserActivities/{dataWarehouseUserActivityName}
        /// Operation Id: DataWarehouseUserActivities_Get
        /// </summary>
        /// <param name="dataWarehouseUserActivityName"> The activity name of the data warehouse. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DataWarehouseUserActivities> Get(DataWarehouseUserActivityName dataWarehouseUserActivityName, CancellationToken cancellationToken = default)
        {
            using var scope = _dataWarehouseUserActivitiesDataWarehouseUserActivitiesClientDiagnostics.CreateScope("DataWarehouseUserActivitiesCollection.Get");
            scope.Start();
            try
            {
                var response = _dataWarehouseUserActivitiesDataWarehouseUserActivitiesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, dataWarehouseUserActivityName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DataWarehouseUserActivities(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List the user activities of a data warehouse which includes running and suspended queries
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/dataWarehouseUserActivities
        /// Operation Id: DataWarehouseUserActivities_ListByDatabase
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DataWarehouseUserActivities" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DataWarehouseUserActivities> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<DataWarehouseUserActivities>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _dataWarehouseUserActivitiesDataWarehouseUserActivitiesClientDiagnostics.CreateScope("DataWarehouseUserActivitiesCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _dataWarehouseUserActivitiesDataWarehouseUserActivitiesRestClient.ListByDatabaseAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DataWarehouseUserActivities(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DataWarehouseUserActivities>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _dataWarehouseUserActivitiesDataWarehouseUserActivitiesClientDiagnostics.CreateScope("DataWarehouseUserActivitiesCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _dataWarehouseUserActivitiesDataWarehouseUserActivitiesRestClient.ListByDatabaseNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DataWarehouseUserActivities(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// List the user activities of a data warehouse which includes running and suspended queries
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/dataWarehouseUserActivities
        /// Operation Id: DataWarehouseUserActivities_ListByDatabase
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DataWarehouseUserActivities" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DataWarehouseUserActivities> GetAll(CancellationToken cancellationToken = default)
        {
            Page<DataWarehouseUserActivities> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _dataWarehouseUserActivitiesDataWarehouseUserActivitiesClientDiagnostics.CreateScope("DataWarehouseUserActivitiesCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _dataWarehouseUserActivitiesDataWarehouseUserActivitiesRestClient.ListByDatabase(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DataWarehouseUserActivities(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DataWarehouseUserActivities> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _dataWarehouseUserActivitiesDataWarehouseUserActivitiesClientDiagnostics.CreateScope("DataWarehouseUserActivitiesCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _dataWarehouseUserActivitiesDataWarehouseUserActivitiesRestClient.ListByDatabaseNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DataWarehouseUserActivities(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/dataWarehouseUserActivities/{dataWarehouseUserActivityName}
        /// Operation Id: DataWarehouseUserActivities_Get
        /// </summary>
        /// <param name="dataWarehouseUserActivityName"> The activity name of the data warehouse. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> ExistsAsync(DataWarehouseUserActivityName dataWarehouseUserActivityName, CancellationToken cancellationToken = default)
        {
            using var scope = _dataWarehouseUserActivitiesDataWarehouseUserActivitiesClientDiagnostics.CreateScope("DataWarehouseUserActivitiesCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(dataWarehouseUserActivityName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/dataWarehouseUserActivities/{dataWarehouseUserActivityName}
        /// Operation Id: DataWarehouseUserActivities_Get
        /// </summary>
        /// <param name="dataWarehouseUserActivityName"> The activity name of the data warehouse. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Exists(DataWarehouseUserActivityName dataWarehouseUserActivityName, CancellationToken cancellationToken = default)
        {
            using var scope = _dataWarehouseUserActivitiesDataWarehouseUserActivitiesClientDiagnostics.CreateScope("DataWarehouseUserActivitiesCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(dataWarehouseUserActivityName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/dataWarehouseUserActivities/{dataWarehouseUserActivityName}
        /// Operation Id: DataWarehouseUserActivities_Get
        /// </summary>
        /// <param name="dataWarehouseUserActivityName"> The activity name of the data warehouse. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DataWarehouseUserActivities>> GetIfExistsAsync(DataWarehouseUserActivityName dataWarehouseUserActivityName, CancellationToken cancellationToken = default)
        {
            using var scope = _dataWarehouseUserActivitiesDataWarehouseUserActivitiesClientDiagnostics.CreateScope("DataWarehouseUserActivitiesCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _dataWarehouseUserActivitiesDataWarehouseUserActivitiesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, dataWarehouseUserActivityName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<DataWarehouseUserActivities>(null, response.GetRawResponse());
                return Response.FromValue(new DataWarehouseUserActivities(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/dataWarehouseUserActivities/{dataWarehouseUserActivityName}
        /// Operation Id: DataWarehouseUserActivities_Get
        /// </summary>
        /// <param name="dataWarehouseUserActivityName"> The activity name of the data warehouse. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DataWarehouseUserActivities> GetIfExists(DataWarehouseUserActivityName dataWarehouseUserActivityName, CancellationToken cancellationToken = default)
        {
            using var scope = _dataWarehouseUserActivitiesDataWarehouseUserActivitiesClientDiagnostics.CreateScope("DataWarehouseUserActivitiesCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _dataWarehouseUserActivitiesDataWarehouseUserActivitiesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, dataWarehouseUserActivityName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<DataWarehouseUserActivities>(null, response.GetRawResponse());
                return Response.FromValue(new DataWarehouseUserActivities(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<DataWarehouseUserActivities> IEnumerable<DataWarehouseUserActivities>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<DataWarehouseUserActivities> IAsyncEnumerable<DataWarehouseUserActivities>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
