import React from 'react';
import { Route, Routes } from 'react-router-dom';
import { Layout } from '../components/Layout/Layout';
import { Articles } from './Articles';

export const Index = () => {
	return (
		<>
			<Routes>
				<Route path="/" element={<Layout />}>
					<Route index element={<Articles />} />
				</Route>
			</Routes>
		</>
	);
};
