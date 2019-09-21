import { Component, OnInit } from '@angular/core';
import { TaskModel } from '../models/task-model';
import { ApiService } from '../service/api-service';
import { ProjectListModelComponent } from 'src/app/model-popup/project-list-model/project-list-model.component';
import { DialogService } from "ng2-bootstrap-modal";
import { ProjectModel } from '../models/project-model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-view-tasks',
  templateUrl: './view-tasks.component.html',
  styleUrls: ['./view-tasks.component.css']
})
export class ViewTasksComponent implements OnInit {
  ProjectID?: number;
  Project: string;
  TaskID: number;
  Task: string;
  ParentTaskID?: number;
  ParentTask: string;
  Priority: number;
  StartDate?: Date;
  EndDate?: Date;
  UserID: number;
  UserName: string;
  taskList: TaskModel[];
  filteredList: TaskModel[];
  taskListCount: number;
  projectList: ProjectModel[];

  constructor(private apiService: ApiService, private dialogService: DialogService, private router: Router) {

  }

  ngOnInit() {
  }

  public EndTask(task: TaskModel) {
    this.apiService.EndTask(task).subscribe((data) => {
      this.GetTasks(this.ProjectID);
      document.getElementById('userMsg').innerText = "Task ended successfully...";
      document.getElementById('userMsg').style.color = "green";
    },
      function (error) {
        console.log(error);
        document.getElementById('userMsg').innerText = "Error occurred. Please try again...";
        document.getElementById('userMsg').style.color = "red";
      })
  }

  EditTask(task: TaskModel) {
    this.router.navigate(['/addTasks', { task: JSON.stringify(task) }], { skipLocationChange: true });
  }

  openProjectDialog() {
    let disposable = this.dialogService.addDialog(ProjectListModelComponent, this.projectList)
      .subscribe((selectedProject) => {
        if (selectedProject) {
          this.ProjectID = selectedProject.ProjectID;
          this.Project = selectedProject.Project;
          this.GetTasks(this.ProjectID);
        }
      });
    setTimeout(() => {
      disposable.unsubscribe();
    }, 10000);
  }
  directionSDate=1;
  directionEDate=1;
  directionPriority=1;
  directionStatus=1;
  sortingTask(sort,property,direction) {
    var self=this;
    if (sort == 'SDate') {
      if(self.directionSDate==1)
      self.directionSDate=-1;
      else
      self.directionSDate=1;
     
      direction=self.directionSDate;
    }
    else if (sort == 'EDate') {
      if(self.directionEDate==1)
      self.directionEDate=-1;
      else
      self.directionEDate=1;
     
      direction=self.directionEDate;
    }
    else if (sort == 'Priority') {
      if(self.directionPriority==1)
      self.directionPriority=-1;
      else
      self.directionPriority=1;
     
      direction=self.directionPriority;
    }
    else if (sort == 'Completed') {
      if(self.directionStatus==1)
      self.directionStatus=-1;
      else
      self.directionStatus=1;
     
      direction=self.directionStatus;
   
    }

    self.filteredList.sort(function compare(a, b) {
      let comparison = 0;
      if (a[property] > b[property]) {
          comparison = 1 * direction;
      } else if (a[property] < b[property]) {
          comparison = -1 * direction;
      }
      return comparison;
  });
  }

  GetTasks(projectID) {
    this.apiService.GetTasks(projectID)
      .subscribe((data: TaskModel[]) => {
        console.log(data);
        this.taskList = data;
        this.assignCopy();
      },
        function (error) {
          console.log(error);
        });
  }

  assignCopy() {
    this.filteredList = Object.assign([], this.taskList);
    this.taskListCount = this.filteredList.length;
  }

}
