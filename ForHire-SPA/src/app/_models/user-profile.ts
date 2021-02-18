export interface UserProfile {
  id: number;
  photoUrl?: string;
  headerPhotoUrl: string;
  firstName: string;
  lastName: string;
  currentPosition: string;
  yearsOfExperience: number;
  rolesOfInterest: string;
  description: string;
  socialProfiles: object;
  achievements: string;
  education: object;
  experience: object;
  skills: string[];
  location: string;
}
