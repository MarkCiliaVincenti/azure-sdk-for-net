// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    /// <summary> A Class representing a ExtendedDatabaseBlobAuditingPolicy along with the instance operations that can be performed on it. </summary>
    public partial class ExtendedDatabaseBlobAuditingPolicy : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="ExtendedDatabaseBlobAuditingPolicy"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string serverName, string databaseName, string blobAuditingPolicyName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/extendedAuditingSettings/{blobAuditingPolicyName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _extendedDatabaseBlobAuditingPolicyClientDiagnostics;
        private readonly ExtendedDatabaseBlobAuditingPoliciesRestOperations _extendedDatabaseBlobAuditingPolicyRestClient;
        private readonly ExtendedDatabaseBlobAuditingPolicyData _data;

        /// <summary> Initializes a new instance of the <see cref="ExtendedDatabaseBlobAuditingPolicy"/> class for mocking. </summary>
        protected ExtendedDatabaseBlobAuditingPolicy()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "ExtendedDatabaseBlobAuditingPolicy"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal ExtendedDatabaseBlobAuditingPolicy(ArmClient client, ExtendedDatabaseBlobAuditingPolicyData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="ExtendedDatabaseBlobAuditingPolicy"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ExtendedDatabaseBlobAuditingPolicy(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _extendedDatabaseBlobAuditingPolicyClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string extendedDatabaseBlobAuditingPolicyApiVersion);
            _extendedDatabaseBlobAuditingPolicyRestClient = new ExtendedDatabaseBlobAuditingPoliciesRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, extendedDatabaseBlobAuditingPolicyApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Sql/servers/databases/extendedAuditingSettings";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual ExtendedDatabaseBlobAuditingPolicyData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Gets an extended database&apos;s blob auditing policy.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/extendedAuditingSettings/{blobAuditingPolicyName}
        /// Operation Id: ExtendedDatabaseBlobAuditingPolicies_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ExtendedDatabaseBlobAuditingPolicy>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _extendedDatabaseBlobAuditingPolicyClientDiagnostics.CreateScope("ExtendedDatabaseBlobAuditingPolicy.Get");
            scope.Start();
            try
            {
                var response = await _extendedDatabaseBlobAuditingPolicyRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ExtendedDatabaseBlobAuditingPolicy(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets an extended database&apos;s blob auditing policy.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/extendedAuditingSettings/{blobAuditingPolicyName}
        /// Operation Id: ExtendedDatabaseBlobAuditingPolicies_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ExtendedDatabaseBlobAuditingPolicy> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _extendedDatabaseBlobAuditingPolicyClientDiagnostics.CreateScope("ExtendedDatabaseBlobAuditingPolicy.Get");
            scope.Start();
            try
            {
                var response = _extendedDatabaseBlobAuditingPolicyRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ExtendedDatabaseBlobAuditingPolicy(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
