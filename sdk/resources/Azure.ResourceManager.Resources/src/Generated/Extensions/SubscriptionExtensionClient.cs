// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    /// <summary> A class to add extension methods to Subscription. </summary>
    internal partial class SubscriptionExtensionClient : ArmResource
    {
        private ClientDiagnostics _applicationClientDiagnostics;
        private ApplicationsRestOperations _applicationRestClient;
        private ClientDiagnostics _jitRequestClientDiagnostics;
        private JitRequestsRestOperations _jitRequestRestClient;
        private ClientDiagnostics _deploymentScriptClientDiagnostics;
        private DeploymentScriptsRestOperations _deploymentScriptRestClient;
        private ClientDiagnostics _templateSpecClientDiagnostics;
        private TemplateSpecsRestOperations _templateSpecRestClient;

        /// <summary> Initializes a new instance of the <see cref="SubscriptionExtensionClient"/> class for mocking. </summary>
        protected SubscriptionExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SubscriptionExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SubscriptionExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics ApplicationClientDiagnostics => _applicationClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.Resources", Application.ResourceType.Namespace, DiagnosticOptions);
        private ApplicationsRestOperations ApplicationRestClient => _applicationRestClient ??= new ApplicationsRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, GetApiVersionOrNull(Application.ResourceType));
        private ClientDiagnostics JitRequestClientDiagnostics => _jitRequestClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.Resources", JitRequest.ResourceType.Namespace, DiagnosticOptions);
        private JitRequestsRestOperations JitRequestRestClient => _jitRequestRestClient ??= new JitRequestsRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, GetApiVersionOrNull(JitRequest.ResourceType));
        private ClientDiagnostics DeploymentScriptClientDiagnostics => _deploymentScriptClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.Resources", DeploymentScript.ResourceType.Namespace, DiagnosticOptions);
        private DeploymentScriptsRestOperations DeploymentScriptRestClient => _deploymentScriptRestClient ??= new DeploymentScriptsRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, GetApiVersionOrNull(DeploymentScript.ResourceType));
        private ClientDiagnostics TemplateSpecClientDiagnostics => _templateSpecClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.Resources", TemplateSpec.ResourceType.Namespace, DiagnosticOptions);
        private TemplateSpecsRestOperations TemplateSpecRestClient => _templateSpecRestClient ??= new TemplateSpecsRestOperations(Pipeline, DiagnosticOptions.ApplicationId, BaseUri, GetApiVersionOrNull(TemplateSpec.ResourceType));

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary> Gets a collection of Deployments in the Deployment. </summary>
        /// <returns> An object representing collection of Deployments and their operations over a Deployment. </returns>
        public virtual DeploymentCollection GetDeployments()
        {
            return GetCachedClient(Client => new DeploymentCollection(Client, Id));
        }

        /// <summary>
        /// Gets all the applications within a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Solutions/applications
        /// Operation Id: Applications_ListBySubscription
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="Application" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<Application> GetApplicationsAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<Application>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = ApplicationClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetApplications");
                scope.Start();
                try
                {
                    var response = await ApplicationRestClient.ListBySubscriptionAsync(Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Application(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<Application>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = ApplicationClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetApplications");
                scope.Start();
                try
                {
                    var response = await ApplicationRestClient.ListBySubscriptionNextPageAsync(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new Application(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets all the applications within a subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Solutions/applications
        /// Operation Id: Applications_ListBySubscription
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="Application" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<Application> GetApplications(CancellationToken cancellationToken = default)
        {
            Page<Application> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = ApplicationClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetApplications");
                scope.Start();
                try
                {
                    var response = ApplicationRestClient.ListBySubscription(Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Application(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<Application> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = ApplicationClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetApplications");
                scope.Start();
                try
                {
                    var response = ApplicationRestClient.ListBySubscriptionNextPage(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new Application(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Retrieves all JIT requests within the subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Solutions/jitRequests
        /// Operation Id: JitRequests_ListBySubscription
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="JitRequest" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<JitRequest> GetJitRequestDefinitionsAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<JitRequest>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = JitRequestClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetJitRequestDefinitions");
                scope.Start();
                try
                {
                    var response = await JitRequestRestClient.ListBySubscriptionAsync(Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new JitRequest(Client, value)), null, response.GetRawResponse());
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
        /// Retrieves all JIT requests within the subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Solutions/jitRequests
        /// Operation Id: JitRequests_ListBySubscription
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="JitRequest" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<JitRequest> GetJitRequestDefinitions(CancellationToken cancellationToken = default)
        {
            Page<JitRequest> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = JitRequestClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetJitRequestDefinitions");
                scope.Start();
                try
                {
                    var response = JitRequestRestClient.ListBySubscription(Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new JitRequest(Client, value)), null, response.GetRawResponse());
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
        /// Lists all deployment scripts for a given subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Resources/deploymentScripts
        /// Operation Id: DeploymentScripts_ListBySubscription
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DeploymentScript" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DeploymentScript> GetDeploymentScriptsAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<DeploymentScript>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = DeploymentScriptClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetDeploymentScripts");
                scope.Start();
                try
                {
                    var response = await DeploymentScriptRestClient.ListBySubscriptionAsync(Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DeploymentScript(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DeploymentScript>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = DeploymentScriptClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetDeploymentScripts");
                scope.Start();
                try
                {
                    var response = await DeploymentScriptRestClient.ListBySubscriptionNextPageAsync(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DeploymentScript(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all deployment scripts for a given subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Resources/deploymentScripts
        /// Operation Id: DeploymentScripts_ListBySubscription
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DeploymentScript" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DeploymentScript> GetDeploymentScripts(CancellationToken cancellationToken = default)
        {
            Page<DeploymentScript> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = DeploymentScriptClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetDeploymentScripts");
                scope.Start();
                try
                {
                    var response = DeploymentScriptRestClient.ListBySubscription(Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DeploymentScript(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DeploymentScript> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = DeploymentScriptClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetDeploymentScripts");
                scope.Start();
                try
                {
                    var response = DeploymentScriptRestClient.ListBySubscriptionNextPage(nextLink, Id.SubscriptionId, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DeploymentScript(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all the Template Specs within the specified subscriptions.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Resources/templateSpecs
        /// Operation Id: TemplateSpecs_ListBySubscription
        /// </summary>
        /// <param name="expand"> Allows for expansion of additional Template Spec details in the response. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="TemplateSpec" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<TemplateSpec> GetTemplateSpecsAsync(TemplateSpecExpandKind? expand = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<TemplateSpec>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = TemplateSpecClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetTemplateSpecs");
                scope.Start();
                try
                {
                    var response = await TemplateSpecRestClient.ListBySubscriptionAsync(Id.SubscriptionId, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TemplateSpec(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<TemplateSpec>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = TemplateSpecClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetTemplateSpecs");
                scope.Start();
                try
                {
                    var response = await TemplateSpecRestClient.ListBySubscriptionNextPageAsync(nextLink, Id.SubscriptionId, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new TemplateSpec(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all the Template Specs within the specified subscriptions.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Resources/templateSpecs
        /// Operation Id: TemplateSpecs_ListBySubscription
        /// </summary>
        /// <param name="expand"> Allows for expansion of additional Template Spec details in the response. Optional. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="TemplateSpec" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<TemplateSpec> GetTemplateSpecs(TemplateSpecExpandKind? expand = null, CancellationToken cancellationToken = default)
        {
            Page<TemplateSpec> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = TemplateSpecClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetTemplateSpecs");
                scope.Start();
                try
                {
                    var response = TemplateSpecRestClient.ListBySubscription(Id.SubscriptionId, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TemplateSpec(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<TemplateSpec> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = TemplateSpecClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetTemplateSpecs");
                scope.Start();
                try
                {
                    var response = TemplateSpecRestClient.ListBySubscriptionNextPage(nextLink, Id.SubscriptionId, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new TemplateSpec(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
