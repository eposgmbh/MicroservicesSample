kubectl apply -f https://raw.githubusercontent.com/kubernetes/dashboard/master/src/deploy/recommended/kubernetes-dashboard.yaml | Out-Null

$jobinfo = Start-Job -ScriptBlock { kubectl proxy }
$jobname = $jobinfo.Name
$env:KUBERNETES_DASHBOARD_JOB_NAME = $jobname

Start-Process http://localhost:8001/ui
