# EventFlow Demo App

I just created demo project by hand and tested eventflow.
<br>(In addition to original repo, docker support (I know, unnecessary for this :)) and swagger was added.)

Original repo: https://github.com/johnny-chan/EventFlowDemo
<br>Documentation: http://docs.geteventflow.net/GettingStarted.html

<b>You can try by just download and start.</b>
- [POST] /api/Examples (delete parentheses and write any int)
- Copy "aggregateId"s value from response body (like example-4b3ab41c-b7f5-470d-9f58-138209c95071)
- Use the value at [GET] /api/Examples/{id} (/api/Examples/example-4b3ab41c-b7f5-470d-9f58-138209c95071)
<br><b>And voila!</b>
 Debug step by step and see whats happening in the background.