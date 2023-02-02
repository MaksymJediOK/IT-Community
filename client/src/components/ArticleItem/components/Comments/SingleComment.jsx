import React from 'react'
import styles from './Coments.module.scss'
import { Avatar, Box } from '@mui/material'
import { CorrectDate } from 'utils/CorrectDate'

export const SingleComment = (props) => {
	const { body, date, userName } = props
	const validDate = CorrectDate(date)

	return (
		<div className={styles.comment}>
			<Avatar />
			<Box sx={{ marginLeft: '12px' }}>
				<Box sx={{ display: 'flex' }}>
					<div className={styles.comment_name}>{userName}</div>
					<span className={styles.comment_date}>{validDate}</span>
				</Box>
				<div className={styles.comment_content}>{body}</div>
				<div className={styles.comment_action}>
					<div className={styles.comment_action_text}>Reply</div>
					<div className={styles.comment_action_text}>Like</div>
				</div>
			</Box>
		</div>
	)
}
