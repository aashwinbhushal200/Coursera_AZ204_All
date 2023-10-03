//git clone
git clone
https://github.com/MicrosoftDocs/mslearn-advocates.azure-functions-and-signalr.git serverless-demo
cd serverless - demo
code start
//define a name for your Azure Storage account.
export STORAGE_ACCOUNT_NAME = mslsigrstorage$(openssl rand - hex 5)
 echo "Storage Account Name: $STORAGE_ACCOUNT_NAME"
//command to create a storage account for your function and static website.
az storage account create \--name $STORAGE_ACCOUNT_NAME \--resource - group PollingAppdemoResourceGroupaz\--kind StorageV2\--sku Standard_LRS
//create a new Azure Cosmos DB account
az cosmosdb create  \
--name msl - sigr - cosmos - $(openssl rand - hex 5) \
--resource - group[sandbox resource group name]
//Update local settings
STORAGE_CONNECTION_STRING = $(az storage account show - connection - string \
    --name $(az storage account list \
        --resource - group[sandbox resource group name]\
        --query[0].name - o tsv) \
    --resource - group[sandbox resource group name]\
    --query "connectionString" - o tsv)

COSMOSDB_ACCOUNT_NAME = $(az cosmosdb list \
    --resource - group[sandbox resource group name]\
    --query[0].name - o tsv)

COSMOSDB_CONNECTION_STRING = $(az cosmosdb list - connection - strings  \
    --name $COSMOSDB_ACCOUNT_NAME \
    --resource - group[sandbox resource group name]\
    --query "connectionStrings[?description=='Primary SQL Connection String'].connectionString" - o tsv)

COSMOSDB_MASTER_KEY = $(az cosmosdb list - keys \
    --name $COSMOSDB_ACCOUNT_NAME \
    --resource - group[sandbox resource group name]\
    --query primaryMasterKey - o tsv)

printf "\n\nReplace <STORAGE_CONNECTION_STRING> with:\n$STORAGE_CONNECTION_STRING\n\nReplace <COSMOSDB_CONNECTION_STRING> with:\n$COSMOSDB_CONNECTION_STRING\n\nReplace <COSMOSDB_MASTER_KEY> with:\n$COSMOSDB_MASTER_KEY\n\n"

//RUN THE APPLICATION:
npm install
npm start
npm run update - data


PollingAppdemoResourceGroupaz storage account create
--name $STORAGE_ACCOUNT_NAME
--resource - group PollingAppdemoResourceGroup
--kind StorageV2--sku Standard_LRS


az cosmosdb create--name msl - sigr - cosmos - $(openssl rand - hex 5)
--resource - group PollingAppdemoResourceGroup

//Update local settings 
export STORAGE_CONNECTION_STRING = $(az storage account show - connection - string \
    --name $(az storage account list \
        --resource - group PollingAppdemoResourceGroup\
        --query[0].name - o tsv) \
    --resource - group PollingAppdemoResourceGroup\
    --query "connectionString" - o tsv)

COSMOSDB_ACCOUNT_NAME = $(az cosmosdb list \
    --resource - group PollingAppdemoResourceGroup\
    --query[0].name - o tsv)

COSMOSDB_CONNECTION_STRING = $(az cosmosdb list - connection - strings  \
    --name $COSMOSDB_ACCOUNT_NAME \
    --resource - group PollingAppdemoResourceGroup\
    --query "connectionStrings[?description=='Primary SQL Connection String'].connectionString" - o tsv)

COSMOSDB_MASTER_KEY = $(az cosmosdb list - keys \
    --name $COSMOSDB_ACCOUNT_NAME \
    --resource - group PollingAppdemoResourceGroup\
    --query primaryMasterKey - o tsv)

printf "\n\nReplace <STORAGE_CONNECTION_STRING> with:\n$STORAGE_CONNECTION_STRING\n\nReplace <COSMOSDB_CONNECTION_STRING> with:\n$COSMOSDB_CONNECTION_STRING\n\nReplace <COSMOSDB_MASTER_KEY> with:\n$COSMOSDB_MASTER_KEY\n\n"