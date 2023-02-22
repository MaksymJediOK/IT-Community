import { createSlice } from '@reduxjs/toolkit';

const initialState = {
	anchor: null
}

const popoverSlice = createSlice({
	name: 'UsePopover',
	initialState,
	reducers : {
		setAnchor: (state, action) => {
			state.anchor = action.payload
		},
		closePopover: (state) => {
			state.anchor = null
		}
	}
})

export const {setAnchor, closePopover} = popoverSlice.actions
export const popoverReducer = popoverSlice.reducer