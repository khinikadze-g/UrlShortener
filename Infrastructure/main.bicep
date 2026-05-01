param location string = resourceGroup().location

var uniqueId = uniqueString(resourceGroup().id)

module apiService 'Modules/Compute/appservice.bicep' = {
    name: 'apiDeployment'
    params:{
        appName: 'api-${uniqueId}'
        appServicePlanName: 'plan-api-${uniqueId}'
        location: location
    }
}
