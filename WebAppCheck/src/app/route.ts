import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CheckListComponent } from './check-list/check-list.component';
import { SettingComponent } from './setting/setting.component';
import { ReportComponent } from './report/report.component';
import { AuthGuard } from './_guard/auth.guard';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'checks', component: CheckListComponent, canActivate: [AuthGuard] },
            { path: 'setting', component: SettingComponent },
            { path: 'report', component: ReportComponent },
        ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full'},
];

