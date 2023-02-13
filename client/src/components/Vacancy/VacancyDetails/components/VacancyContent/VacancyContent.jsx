import React from 'react'
import styles from './VacancyContent.module.scss'
import { Avatar, Button, Stack, Box } from '@mui/material'
import BookmarkIcon from '@mui/icons-material/Bookmark'
import VisibilityIcon from '@mui/icons-material/Visibility'
import VerifiedIcon from '@mui/icons-material/Verified'
import BookmarkAddOutlinedIcon from '@mui/icons-material/BookmarkAddOutlined'
import InsertLinkOutlinedIcon from '@mui/icons-material/InsertLinkOutlined'
import MoreHorizOutlinedIcon from '@mui/icons-material/MoreHorizOutlined'

export const VacancyContent = () => {
	return (
		<>
			<div className={styles.title}>Junior FrontEnd Developer</div>
			<Stack
				direction='row'
				justifyContent='space-between'
				alignItems='center'
				sx={{ m: '12px 0' }}
			>
				<div className={styles.date}>Sep 12, 2022</div>
				<Stack direction='row' gap='18px'>
					<Stack direction='row' alignItems='center'>
						<BookmarkIcon />
						<div className={styles.stat}>2.5K</div>
					</Stack>
					<Stack direction='row' alignItems='center'>
						<VisibilityIcon />
						<div className={styles.stat}>2.5K</div>
					</Stack>
				</Stack>
			</Stack>
			<div className={styles.temp}></div>
			<Stack direction='row' alignItems='center' justifyContent='space-between'>
				<Button variant='outlined' size='large' sx={{ width: '170px' }}>
					APPLY
				</Button>
				<div className={styles.share_container}>
					<BookmarkAddOutlinedIcon />
					<InsertLinkOutlinedIcon />
					<MoreHorizOutlinedIcon />
				</div>
			</Stack>

			<Stack
				direction='row'
				alignItems='center'
				justifyContent='space-between'
				sx={{ mt: '45px' }}
			>
				<Box>
					<Stack direction='row' alignItems='center'>
						<Avatar sx={{ width: 96, height: 96 }}>EPAM</Avatar>
						<Stack direction='row' alignItems='center'>
							<Box sx={{ ml: '26px' }}>
								<Stack direction='row' alignItems='center'>
									<div className={styles.company_title}>EPAM UKRAINE</div>
									<VerifiedIcon sx={{ width: '20px', height: '20px', ml: '11px' }} />
								</Stack>
								<div className={styles.workers}>2000+ workers</div>
								<div className={styles.speciality}>
									{' '}
									UX / UI Design Agency located in Kyiv
								</div>
							</Box>
						</Stack>
					</Stack>
				</Box>

				<Button variant='outlined' size='small'>
					FOLLOW
				</Button>
			</Stack>
		</>
	)
}
