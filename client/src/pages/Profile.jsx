import React from 'react';
import { GeneralProfile } from '../features/Profile';
import { Route } from 'react-router-dom';

export const Profile = () => {
	return (
		<>
			<Route path='/general' element={<GeneralProfile />} />
		</>
	);
};
