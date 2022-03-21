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
    /// <summary> A class representing collection of ServerAdvisor and their operations over its parent. </summary>
    public partial class ServerAdvisorCollection : ArmCollection, IEnumerable<ServerAdvisor>, IAsyncEnumerable<ServerAdvisor>
    {
        private readonly ClientDiagnostics _serverAdvisorClientDiagnostics;
        private readonly ServerAdvisorsRestOperations _serverAdvisorRestClient;

        /// <summary> Initializes a new instance of the <see cref="ServerAdvisorCollection"/> class for mocking. </summary>
        protected ServerAdvisorCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ServerAdvisorCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ServerAdvisorCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _serverAdvisorClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ServerAdvisor.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ServerAdvisor.ResourceType, out string serverAdvisorApiVersion);
            _serverAdvisorRestClient = new ServerAdvisorsRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, serverAdvisorApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SqlServer.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SqlServer.ResourceType), nameof(id));
        }

        /// <summary>
        /// Gets a server advisor.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/advisors/{advisorName}
        /// Operation Id: ServerAdvisors_Get
        /// </summary>
        /// <param name="advisorName"> The name of the Server Advisor. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="advisorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="advisorName"/> is null. </exception>
        public virtual async Task<Response<ServerAdvisor>> GetAsync(string advisorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(advisorName, nameof(advisorName));

            using var scope = _serverAdvisorClientDiagnostics.CreateScope("ServerAdvisorCollection.Get");
            scope.Start();
            try
            {
                var response = await _serverAdvisorRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, advisorName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ServerAdvisor(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a server advisor.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/advisors/{advisorName}
        /// Operation Id: ServerAdvisors_Get
        /// </summary>
        /// <param name="advisorName"> The name of the Server Advisor. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="advisorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="advisorName"/> is null. </exception>
        public virtual Response<ServerAdvisor> Get(string advisorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(advisorName, nameof(advisorName));

            using var scope = _serverAdvisorClientDiagnostics.CreateScope("ServerAdvisorCollection.Get");
            scope.Start();
            try
            {
                var response = _serverAdvisorRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, advisorName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ServerAdvisor(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of server advisors.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/advisors
        /// Operation Id: ServerAdvisors_ListByServer
        /// </summary>
        /// <param name="expand"> The child resources to include in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ServerAdvisor" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ServerAdvisor> GetAllAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ServerAdvisor>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _serverAdvisorClientDiagnostics.CreateScope("ServerAdvisorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _serverAdvisorRestClient.ListByServerAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Select(value => new ServerAdvisor(Client, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Gets a list of server advisors.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/advisors
        /// Operation Id: ServerAdvisors_ListByServer
        /// </summary>
        /// <param name="expand"> The child resources to include in the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ServerAdvisor" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ServerAdvisor> GetAll(string expand = null, CancellationToken cancellationToken = default)
        {
            Page<ServerAdvisor> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _serverAdvisorClientDiagnostics.CreateScope("ServerAdvisorCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _serverAdvisorRestClient.ListByServer(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Select(value => new ServerAdvisor(Client, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/advisors/{advisorName}
        /// Operation Id: ServerAdvisors_Get
        /// </summary>
        /// <param name="advisorName"> The name of the Server Advisor. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="advisorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="advisorName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string advisorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(advisorName, nameof(advisorName));

            using var scope = _serverAdvisorClientDiagnostics.CreateScope("ServerAdvisorCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(advisorName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/advisors/{advisorName}
        /// Operation Id: ServerAdvisors_Get
        /// </summary>
        /// <param name="advisorName"> The name of the Server Advisor. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="advisorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="advisorName"/> is null. </exception>
        public virtual Response<bool> Exists(string advisorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(advisorName, nameof(advisorName));

            using var scope = _serverAdvisorClientDiagnostics.CreateScope("ServerAdvisorCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(advisorName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/advisors/{advisorName}
        /// Operation Id: ServerAdvisors_Get
        /// </summary>
        /// <param name="advisorName"> The name of the Server Advisor. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="advisorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="advisorName"/> is null. </exception>
        public virtual async Task<Response<ServerAdvisor>> GetIfExistsAsync(string advisorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(advisorName, nameof(advisorName));

            using var scope = _serverAdvisorClientDiagnostics.CreateScope("ServerAdvisorCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _serverAdvisorRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, advisorName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ServerAdvisor>(null, response.GetRawResponse());
                return Response.FromValue(new ServerAdvisor(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/advisors/{advisorName}
        /// Operation Id: ServerAdvisors_Get
        /// </summary>
        /// <param name="advisorName"> The name of the Server Advisor. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="advisorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="advisorName"/> is null. </exception>
        public virtual Response<ServerAdvisor> GetIfExists(string advisorName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(advisorName, nameof(advisorName));

            using var scope = _serverAdvisorClientDiagnostics.CreateScope("ServerAdvisorCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _serverAdvisorRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, advisorName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ServerAdvisor>(null, response.GetRawResponse());
                return Response.FromValue(new ServerAdvisor(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ServerAdvisor> IEnumerable<ServerAdvisor>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ServerAdvisor> IAsyncEnumerable<ServerAdvisor>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
