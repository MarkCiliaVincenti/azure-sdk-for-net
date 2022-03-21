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
    /// <summary> A Class representing a ManagedDatabaseSecurityAlertPolicy along with the instance operations that can be performed on it. </summary>
    public partial class ManagedDatabaseSecurityAlertPolicy : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="ManagedDatabaseSecurityAlertPolicy"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string managedInstanceName, string databaseName, string securityAlertPolicyName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/securityAlertPolicies/{securityAlertPolicyName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _managedDatabaseSecurityAlertPolicyClientDiagnostics;
        private readonly ManagedDatabaseSecurityAlertPoliciesRestOperations _managedDatabaseSecurityAlertPolicyRestClient;
        private readonly ManagedDatabaseSecurityAlertPolicyData _data;

        /// <summary> Initializes a new instance of the <see cref="ManagedDatabaseSecurityAlertPolicy"/> class for mocking. </summary>
        protected ManagedDatabaseSecurityAlertPolicy()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "ManagedDatabaseSecurityAlertPolicy"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal ManagedDatabaseSecurityAlertPolicy(ArmClient client, ManagedDatabaseSecurityAlertPolicyData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="ManagedDatabaseSecurityAlertPolicy"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal ManagedDatabaseSecurityAlertPolicy(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _managedDatabaseSecurityAlertPolicyClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string managedDatabaseSecurityAlertPolicyApiVersion);
            _managedDatabaseSecurityAlertPolicyRestClient = new ManagedDatabaseSecurityAlertPoliciesRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, managedDatabaseSecurityAlertPolicyApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Sql/managedInstances/databases/securityAlertPolicies";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual ManagedDatabaseSecurityAlertPolicyData Data
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
        /// Gets a managed database&apos;s security alert policy.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/securityAlertPolicies/{securityAlertPolicyName}
        /// Operation Id: ManagedDatabaseSecurityAlertPolicies_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ManagedDatabaseSecurityAlertPolicy>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _managedDatabaseSecurityAlertPolicyClientDiagnostics.CreateScope("ManagedDatabaseSecurityAlertPolicy.Get");
            scope.Start();
            try
            {
                var response = await _managedDatabaseSecurityAlertPolicyRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ManagedDatabaseSecurityAlertPolicy(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a managed database&apos;s security alert policy.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/databases/{databaseName}/securityAlertPolicies/{securityAlertPolicyName}
        /// Operation Id: ManagedDatabaseSecurityAlertPolicies_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ManagedDatabaseSecurityAlertPolicy> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _managedDatabaseSecurityAlertPolicyClientDiagnostics.CreateScope("ManagedDatabaseSecurityAlertPolicy.Get");
            scope.Start();
            try
            {
                var response = _managedDatabaseSecurityAlertPolicyRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ManagedDatabaseSecurityAlertPolicy(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
