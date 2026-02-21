import { Severity } from "./Severity";

export interface Events
{
  timeStamp: string;
  severity: Severity;
  message: string;
}

export interface EventLogResponse
{
  data: Events[],
  errorMessage: string
}