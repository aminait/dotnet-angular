export interface UserProfile {
  id: number;
  photoUrl: string;
  headerUrl: string;
  firstName: string;
  lastName: string;
  currentPosition: string;
  yearsOfExperience: number;
  rolesOfInterest: string;
  bio: string;
  socialProfiles: object;
  achievements: string;
  education: object;
  experience: object;
  skills: string[];
}
