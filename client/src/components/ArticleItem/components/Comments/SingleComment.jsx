import React from 'react'
import styles from './Coments.module.scss'
import { Avatar, Box } from '@mui/material'

export const SingleComment = () => {
	return (
		<div className={styles.comment}>
			<Avatar />
			<Box sx={{ marginLeft: '12px' }}>
				<Box sx={{ display: 'flex' }}>
					<div className={styles.comment_name}>Name surname</div>
					<span className={styles.comment_date}>Sep 12, 2022</span>
				</Box>
				<div className={styles.comment_content}>
					This is a paragraph with more information about something important. This something
					has many uses and is made of 100% recycled material.
				</div>
				<div className={styles.comment_action}>
					<div className={styles.comment_action_text}>Reply</div>
					<div className={styles.comment_action_text}>Like</div>
				</div>
			</Box>
		</div>
	)
}
