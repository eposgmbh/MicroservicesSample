$jobname = $env:KUBERNETES_DASHBOARD_JOB_NAME
$job = Get-Job -Name $jobname

Stop-Job $job
Remove-Job $job

$env:KUBERNETES_DASHBOARD_JOB_NAME = ""
