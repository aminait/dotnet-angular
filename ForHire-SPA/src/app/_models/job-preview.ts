export interface JobPreview {
  id: number;
  title: string;
  companyName: string;
  description: string;
  timePosted: string;
  isRecruiting: boolean;
  isSaved: boolean;
  isHidden: boolean;
  isExpanded: boolean;
  redirectLink?: string;
}
