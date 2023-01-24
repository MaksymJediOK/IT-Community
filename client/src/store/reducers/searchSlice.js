import { createSlice } from '@reduxjs/toolkit';

const initialState = {
	search: '',
};

const searchSlice = createSlice({
	name: '@search',
	initialState,
	reducers: {
		setSearch: (state, action) => {
			state = action.payload;
			return state;
		},
	},
});

export const searchReducer = searchSlice.reducer;
export const { setSearch } = searchSlice.actions;
