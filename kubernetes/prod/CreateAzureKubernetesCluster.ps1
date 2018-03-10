# Resource group erzeugen
az group create --resource-group kube-prod --location westeurope

# AKS Kubernetes Cluster mit einem Node anlegen
az aks create --resource-group kube-prod --name mongo-cluster --node-count 1 --generate-ssh-keys

# Credentials holen und kubectl Context switchen
az aks get-credentials --resource-group kube-prod --name sample-cluster
