import React, { useState } from 'react'
import styles from './ItemCard.module.scss'
import FavoriteBorderOutlinedIcon from '@mui/icons-material/FavoriteBorderOutlined'
import ChatBubbleOutlineOutlinedIcon from '@mui/icons-material/ChatBubbleOutlineOutlined'
import VisibilityOutlinedIcon from '@mui/icons-material/VisibilityOutlined'
import BookmarkAddOutlinedIcon from '@mui/icons-material/BookmarkAddOutlined'
import BookmarkAddedIcon from '@mui/icons-material/BookmarkAdded'
import InsertLinkOutlinedIcon from '@mui/icons-material/InsertLinkOutlined'
import MoreHorizOutlinedIcon from '@mui/icons-material/MoreHorizOutlined'
import { CorrectDate } from 'utils/CorrectDate'
import { useAddToBookmarksMutation, useIsBookmarkedQuery } from '../../../../services/bookmarkApi'
import { IconButton } from '@mui/material'

export const ItemCard = (props) => {
	const [currentError, setCurrentError] = useState('')
	const { data, isLoading } = useIsBookmarkedQuery()
	const [addToBookmarks] = useAddToBookmarksMutation()
	const { id, title, description, body, views, date, thumbnail, likes } = props
	const validDate = CorrectDate(date)
	const handleBookmark = () => {
		addToBookmarks(id)
			.unwrap()
			.catch((error) => console.error('rejected', error))
	}
	return (
		<>
			<h5 className={styles.date}>{validDate}</h5>
			<h2 className={styles.title}>{title}</h2>
			<div className={styles.subtitle}>{description}</div>
			<div className={styles.content_box}>
				<img className={styles.picture} src={thumbnail} alt={title} />
			</div>
			<div className={styles.content_box}>{body}</div>
			<div className={styles.tag_container}>
				{/*render tags in future*/}
				<div className={styles.tag}>
					<div className={styles.tag_text}>Design</div>
				</div>
				<div className={styles.tag}>
					<div className={styles.tag_text}>Design</div>
				</div>
				<div className={styles.tag}>
					<div className={styles.tag_text}>Design</div>
				</div>
				<div className={styles.tag}>
					<div className={styles.tag_text}>Design</div>
				</div>
				<div className={styles.tag}>
					<div className={styles.tag_text}>Design</div>
				</div>
			</div>
			<div className={styles.between_container}>
				<div className={styles.flex_container}>
					<div className={styles.stats_item}>
						<FavoriteBorderOutlinedIcon />
						<div className={styles.stats_item_text}>{likes}</div>
					</div>
					<div className={styles.stats_item}>
						<ChatBubbleOutlineOutlinedIcon />
						<div className={styles.stats_item_text}>1</div>
					</div>
					<div className={styles.stats_item}>
						<VisibilityOutlinedIcon />
						<div className={styles.stats_item_text}>{views}</div>
					</div>
				</div>
				<div className={styles.share_container}>
					{isLoading ? (
						''
					) : data.isBookmarked ? (
						<IconButton onClick={handleBookmark}>
							<BookmarkAddedIcon />
						</IconButton>
					) : (
						<IconButton onClick={handleBookmark}>
							<BookmarkAddOutlinedIcon />
						</IconButton>
					)}
					<IconButton>
						<InsertLinkOutlinedIcon />
					</IconButton>
					<IconButton>
						<MoreHorizOutlinedIcon />
					</IconButton>
				</div>
			</div>
		</>
	)
}
