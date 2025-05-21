<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <title>Bootstrap Work Planner</title>
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <!-- Bootstrap 5 CSS CDN -->
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet">
  <style>
    .planner-container {
      width: 70vw;
      margin: 40px auto;
      background: #fff;
      border-radius: 8px;
      box-shadow: 0 2px 8px rgba(0,0,0,0.1);
      overflow: hidden;
    }
    .planner-header {
      background: #0074d9;
      color: #fff;
      font-weight: bold;
      text-align: center;
    }
    .planner-cell {
      border: 1px solid #ececec;
      min-height: 40px;
      padding: 4px;
      position: relative;
      background: #f8f9fa;
    }
    .task-list {
      list-style: none;
      padding-left: 0;
      margin-bottom: 0;
    }
    .task-item {
      background: #e1f5fe;
      border-radius: 4px;
      margin-bottom: 2px;
      padding: 2px 6px;
      font-size: 0.95em;
      word-break: break-word;
    }
    .add-task-btn {
      position: absolute;
      right: 4px;
      top: 4px;
      background: #0074d9;
      color: #fff;
      border: none;
      border-radius: 3px;
      font-size: 0.8em;
      padding: 0 5px;
      cursor: pointer;
      opacity: 0.7;
      transition: opacity 0.2s;
    }
    .add-task-btn:hover {
      opacity: 1;
    }
  </style>
</head>
<body>
  <div class="planner-container">
    <!-- Header Row -->
    <div class="row planner-header">
      <div class="col text-center">Monday</div>
      <div class="col text-center">Tuesday</div>
      <div class="col text-center">Wednesday</div>
      <div class="col text-center">Thursday</div>
      <div class="col text-center">Friday</div>
      <div class="col text-center">Saturday</div>
      <div class="col text-center">Sunday</div>
    </div>
    <div class="row">
      <!-- 7 columns for days -->
      <div class="col p-0">
        <!-- 24 rows for hours -->
        <div id="col-0"></div>
      </div>
      <div class="col p-0"><div id="col-1"></div></div>
      <div class="col p-0"><div id="col-2"></div></div>
      <div class="col p-0"><div id="col-3"></div></div>
      <div class="col p-0"><div id="col-4"></div></div>
      <div class="col p-0"><div id="col-5"></div></div>
      <div class="col p-0"><div id="col-6"></div></div>
    </div>
  </div>

  <!-- Bootstrap JS CDN -->
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
  <script>
    // Generate 24 rows per column
    for(let day = 0; day < 7; day++) {
      const col = document.getElementById('col-' + day);
      for(let hour = 0; hour < 24; hour++) {
        const cell = document.createElement('div');
        cell.className = 'planner-cell';
        cell.dataset.day = day;
        cell.dataset.hour = hour;

        // Display hour label in the first column
        if(day === 0) {
          const hourLabel = document.createElement('div');
          hourLabel.style.position = 'absolute';
          hourLabel.style.left = '4px';
          hourLabel.style.top = '4px';
          hourLabel.style.fontSize = '0.8em';
          hourLabel.style.opacity = '0.5';
          hourLabel.textContent = hour + ':00';
          cell.appendChild(hourLabel);
        }

        // Task list
        const tasksList = document.createElement('ul');
        tasksList.className = 'task-list';

        // Add task button
        const addBtn = document.createElement('button');
        addBtn.className = 'add-task-btn';
        addBtn.textContent = '+';
        addBtn.onclick = function(e) {
          e.stopPropagation();
          const task = prompt(`Add task for ${hour}:00, ${['Monday','Tuesday','Wednesday','Thursday','Friday','Saturday','Sunday'][day]}`);
          if (task) {
            const li = document.createElement('li');
            li.className = 'task-item';
            li.textContent = task;
            tasksList.appendChild(li);
          }
        };

        cell.appendChild(tasksList);
        cell.appendChild(addBtn);

        col.appendChild(cell);
      }
    }
  </script>
</body>
</html>
