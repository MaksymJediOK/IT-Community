import { configureStore } from '@reduxjs/toolkit';
import { articleApi } from '../services/articleApi';
import { searchReducer } from './reducers/searchSlice';

export const store = configureStore({
	reducer: {
		search: searchReducer,
		[articleApi.reducerPath]: articleApi.reducer
	},
	middleware: (getDefaultMiddleware) => getDefaultMiddleware().concat(articleApi.middleware)
});
