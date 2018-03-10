# kubectl Context auf Standard localhost Context switchen
kubectl config use-context docker-for-desktop

# kubectl Context für AKS Kubernetes Cluster entfernen
kubectl config delete-context kube-prod-cluster

# AKS Kubernetes Cluster (Resource group) löschen
Write-Output "Deleting kube-prod Azure AKS Kubernetes cluster..."
az group delete --name kube-prod --yes
