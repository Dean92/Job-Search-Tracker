import { Job } from './job';

export interface userMember {
  id: number;
  userName: string;
  name: any;
  role: string;
  createdDate: Date;
  lastLoginDate: Date;
  jobs: Job[];
}
