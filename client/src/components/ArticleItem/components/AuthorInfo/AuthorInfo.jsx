import React from 'react'
import styles from './Author.module.scss'
import { Avatar, Button } from '@mui/material'

export const AuthorInfo = () => {
	return (
		<>
			<div>
				<Avatar sx={{ width: 96, height: 96, marginBottom: '18px' }}>H</Avatar>
				<div className={styles.name}>Yevgeniy Yevgeniy</div>
				<div className={styles.follower}>578 follower</div>
				<div className={styles.link}>
					User Experience Designer <br /> https://taplink.cc/olex_world <br />{' '}
					olex.web.world@gmail.com
				</div>
				<Button size='small' variant='outlined'>
					FOLLOW
				</Button>
			</div>

			{/*Similar articles*/}

			<div className={styles.similar_container}>
				<div className={styles.similar}>
					<div className={styles.similar_text}>Similar articles</div>
					<span className={styles.similar_seeMore}>See more suggestion</span>
				</div>

				{/*Single Card */}

				<div className={styles.card}>
					<div className={styles.card_name}>
						<Avatar sx={{ width: 24, height: 24 }} />
						<div className={styles.card_name_text}> Name Surname</div>
					</div>
					<div className={styles.card_title}>Extremely Extremely Very Very Long Long</div>
					<div className={styles.card_date}>Sep 12, 2022</div>
				</div>
				<div className={styles.card}>
					<div className={styles.card_name}>
						<Avatar sx={{ width: 24, height: 24 }} />
						<div className={styles.card_name_text}> Name Surname</div>
					</div>
					<div className={styles.card_title}>Extremely Extremely Very Very Long Long</div>
					<div className={styles.card_date}>Sep 12, 2022</div>
				</div>
				<div className={styles.card}>
					<div className={styles.card_name}>
						<Avatar sx={{ width: 24, height: 24 }} />
						<div className={styles.card_name_text}> Name Surname</div>
					</div>
					<div className={styles.card_title}>Extremely Extremely Very Very Long Long</div>
					<div className={styles.card_date}>Sep 12, 2022</div>
				</div>
			</div>
		</>
	)
}
