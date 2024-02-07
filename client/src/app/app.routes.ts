import { Routes } from '@angular/router';
import { CreateUserComponent } from './pages/user/create-user/create-user.component';
import { UserListComponent } from './pages/user/user-list/user-list.component';
import { UserInfoComponent } from './pages/user/user-info/user-info.component';

export const routes: Routes = [
  {path: "users", component: UserListComponent},
  {path: "create-user", component: CreateUserComponent},
  {path: "users/:id", component: UserInfoComponent}
];
